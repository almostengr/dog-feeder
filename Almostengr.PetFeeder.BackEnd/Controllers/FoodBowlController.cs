using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodBowlController : BaseApiController
    {
        private readonly ILogger<FoodBowlController> _logger;
        private readonly IFoodBowlService _service;

        public FoodBowlController(ILogger<FoodBowlController> logger,
            IFoodBowlService service) : base(logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecentFeedings()
        {
            List<FeedingDto> feedings = await _service.GetRecentFeedingsAsync();
            return Ok(feedings);
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> GetFeedings()
        {
            List<FeedingDto> feedings = await _service.GetFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet]
        public async Task<IActionResult> GetFeeding(int id)
        {
            FeedingDto feeding = await _service.GetFeedingAsync(id);
            return Ok(feeding);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeeding([FromBody] FeedingDto feedingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                FeedingDto response = await _service.PerformFeedingAsync(feedingDto);
            
                return StatusCode(201);
                // return CreatedAtAction(nameof(GetFeeding), new { id = response.FeedingId }, response.AssignToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

    }
}