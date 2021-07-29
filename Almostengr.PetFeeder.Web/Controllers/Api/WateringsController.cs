using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.InputSensor;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Relays;
using Almostengr.PetFeeder.Web.Repository;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class WateringsController : BaseApiController
    {
        private readonly ILogger<WateringsController> _logger;
        private readonly IWateringRepository _wateringRepository;
        private readonly IWaterBowlInputSensor _waterBowlInputSensor;
        private readonly IWaterBowlRelay _waterBowlRelay;

        public WateringsController(ILogger<WateringsController> logger, IWateringRepository wateringRepository,
            IWaterBowlInputSensor waterBowlInputSensor,
            IWaterBowlRelay waterBowlRelay
            ) : base(logger)
        {
            _logger = logger;
            _wateringRepository = wateringRepository;
            _waterBowlInputSensor = waterBowlInputSensor;
            _waterBowlRelay = waterBowlRelay;
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<WateringDto>>> GetAllWateringsAsync()
        {
            var waterings = await _wateringRepository.GetAllAsync();
            var wateringsDto = new List<WateringDto>();

            foreach (var watering in waterings)
            {
                wateringsDto.Add(watering.AssignToDto());
            }

            return Ok(waterings);
        }

        [HttpGet]
        public async Task<ActionResult<IList<WateringDto>>> GetRecentWateringsAsync()
        {
            var waterings = await _wateringRepository.GetRecentWateringsAsync();
            var wateringsDto = new List<WateringDto>();

            foreach (var watering in waterings)
            {
                wateringsDto.Add(watering.AssignToDto());
            }
            
            return Ok(waterings);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<WateringDto>> GetWateringByIdAsync(int id)
        {
            Watering watering = await _wateringRepository.GetByIdAsync(id);

            if (watering == null)
            {
                return NotFound();
            }

            return Ok(watering.AssignToDto());
        }

        [HttpPost]
        public async Task<ActionResult<Watering>> CreateWateringAsync([FromBody] WateringDto wateringDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (_waterBowlInputSensor.IsWaterBowlLow() == false)
                {
                    return Ok();
                }

                Watering watering = new Watering();
                watering.AssignFromDto(wateringDto);

                await _wateringRepository.AddAsync(watering);
                await _wateringRepository.SaveChangesAsync();

                int counter = 0;
                while (_waterBowlInputSensor.IsWaterBowlLow() && counter < 8)
                {
                    _waterBowlRelay.OpenWaterValve();
                    await Task.Delay(TimeSpan.FromMilliseconds(250));
                    counter++;
                }

                _waterBowlRelay.CloseWaterValve();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _waterBowlRelay.CloseWaterValve();
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }
        }

        [HttpGet, Route("status/bowllow")]
        public ActionResult<bool> GetWaterBowlStatus()
        {
            bool status = _waterBowlInputSensor.IsWaterBowlLow();
            return Ok(status);
        }

    }
}