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
using System.Linq;
using Almostengr.PetFeeder.Web.Constants;

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

        // GET /api/waterings/all
        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<WateringDto>>> GetAllWateringsAsync()
        {
            var waterings = await _wateringRepository.GetAllAsync();

            return Ok(waterings.Select(w => w.AssignToDto()).ToList());
        }

        // GET /api/waterings
        [HttpGet]
        public async Task<ActionResult<IList<WateringDto>>> GetRecentWateringsAsync()
        {
            var waterings = await _wateringRepository.GetRecentWateringsAsync();

            return Ok(waterings.Select(w => w.AssignToDto()).ToList());
        }

        // GET /api/waterings/{id}
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<WateringDto>> GetWateringByIdAsync(int id)
        {
            Watering watering = await _wateringRepository.GetByIdAsync(id);

            return Ok(watering.AssignToDto());
        }

        // POST /api/waterings
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
                watering.CreateFromDto(wateringDto);

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
                // return StatusCode(201);
                return CreatedAtAction(nameof(GetWateringByIdAsync), new { id = watering.WateringId }, watering.AssignToDto());
            }
            catch (Exception ex)
            {
                _waterBowlRelay.CloseWaterValve();
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

        // GET /api/waterings/status/bowllow
        [HttpGet, Route("status/bowllow")]
        public ActionResult<bool> GetWaterBowlStatus()
        {
            bool status = _waterBowlInputSensor.IsWaterBowlLow();
            return Ok(status);
        }

    }
}