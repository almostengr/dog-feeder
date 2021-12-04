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
    public class WaterBowlController : BaseApiController
    {
        private readonly IWaterBowlService _service;

        public WaterBowlController(ILogger<WaterBowlController> logger, 
            IWaterBowlService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecentWaterings()
        {
            List<WaterBowlDto> waterings = await _service.GetRecentWateringsAsync();
            return Ok(waterings);
        }

        [HttpGet]
        public async Task<IActionResult> GetWatering(int id)
        {
            WaterBowlDto watering = await _service.GetWaterBowlAsync(id);
            return Ok(watering);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<WaterBowlDto> waterings = await _service.GetAllWateringsAsync();
            return Ok(waterings);
        }
    }
}