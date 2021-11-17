using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Common.Constants;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public class FeedingsController : BaseApiController
    {
        private readonly ILogger<FeedingsController> _logger;
        private readonly IFoodBowlRelay _foodBowlRelay;

        public FeedingsController(ILogger<FeedingsController> logger, IFoodBowlRelay foodBowlRelay) : base(logger)
        {
            _logger = logger;
            _foodBowlRelay = foodBowlRelay;
        }

        // GET /api/feedings
        [HttpGet]
        public async Task<ActionResult<IList<string>>> GetRecentFeedingsAsync()
        {
            // run process that will scan the log for feedings and return the last 10 feedings
            List<string> feedings = new();
            return Ok();
        }

        // POST /api/feedings
        [HttpPost]
        public async Task<ActionResult<FeedingDto>> CreateFeedingAsync([FromBody] FeedingDto feedingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _foodBowlRelay.PerformFeeding(feedingDto);
                var entityJson =  new StringContent(JsonConvert.SerializeObject(feedingDto), Encoding.UTF8, "application/json");
                _logger.LogInformation($"Feeding performed: {entityJson}");
            
                return StatusCode(201);
                // return CreatedAtAction(nameof(GetFeedingByIdAsync), new { id = feeding.FeedingId }, feeding.AssignToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

    }
}