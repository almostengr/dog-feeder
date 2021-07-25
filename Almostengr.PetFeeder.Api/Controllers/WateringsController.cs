using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class WateringsController : BaseController
    {
        private readonly ILogger<WateringsController> _logger;
        private readonly IWateringRepository _wateringRepository;

        public WateringsController(ILogger<WateringsController> logger, IWateringRepository wateringRepository) : base(logger)
        {
            _logger = logger;
            _wateringRepository = wateringRepository;
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<Watering>>> GetAllWateringsAsync()
        {
            var waterings = await _wateringRepository.GetAllAsync();
            return Ok(waterings);
        }

        [HttpGet]
        public async Task<ActionResult<IList<Watering>>> GetRecentWateringsAsync()
        {
            var waterings = await _wateringRepository.GetRecentWateringsAsync();
            return Ok(waterings);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Watering>> GetWateringByIdAsync(int id)
        {
            Watering watering = await _wateringRepository.GetByIdAsync(id);

            if (watering == null)
            {
                return NotFound();
            }

            return Ok(watering);
        }

        [HttpPost]
        public async Task<ActionResult<Watering>> CreateWateringAsync([FromBody] Watering watering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _wateringRepository.CreateAsync(watering);
                await _wateringRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }

            return StatusCode(201);
        }

        [HttpGet, Route("status/bowl")]
        public async Task<ActionResult<bool>> WaterBowlStatus()
        {
            return Ok(false);
        }

        [HttpGet, Route("status/tank")]
        public async Task<ActionResult<bool>> WaterTankStatus()
        {
            return Ok(false);
        }
    }
}