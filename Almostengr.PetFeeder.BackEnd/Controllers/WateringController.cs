using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WateringController : BaseApiController
    {
        private readonly IWateringService _service;

        public WateringController(ILogger<WateringController> logger, 
            IWateringService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatering(int id)
        {
            WateringDto watering = await _service.GetWateringAsync(id);

            if (watering == null)
            {
                return NotFound();
            }

            return Ok(watering);
        }

        [HttpGet]
        public async Task<IActionResult> GetWaterings()
        {
            List<WateringDto> waterings = await _service.GetAllWateringsAsync();
            return Ok(waterings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWatering([FromBody] WateringDto wateringDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            WateringDto createResponse = await _service.CreateWateringAsync(wateringDto);
            return Ok(createResponse);
        }
        
    }
}