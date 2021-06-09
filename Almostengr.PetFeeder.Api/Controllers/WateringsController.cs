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
        private readonly IWateringRepository _repository;

        public WateringsController(ILogger<WateringsController> logger, IWateringRepository repository) : base(logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<Watering>>> GetAllWateringsAsync()
        {
            _logger.LogInformation("Getting all waterings");

            var waterings = await _repository.GetAllAsync();
            return Ok(waterings);
        }

        [HttpGet]
        public async Task<ActionResult<IList<Watering>>> GetRecentWateringsAsync()
        {
            _logger.LogInformation("Get recent waterings");

            var waterings = await _repository.GetRecentWateringsAsync();
            return Ok(waterings);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Watering>> GetWateringByIdAsync(int id)
        {
            _logger.LogInformation("Getting single watering");

            Watering watering = await _repository.GetByIdAsync(id);

            if (watering == null)
            {
                return NotFound();
            }

            return Ok(watering);
        }
    }
}