using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Common.Constants;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public class FeedingsController : BaseApiController
    {
        private readonly ILogger<FeedingsController> _logger;
        private readonly IFoodBowlRelay _feedingRelay;

        public FeedingsController(ILogger<FeedingsController> logger, IFoodBowlRelay feedingRelay) : base(logger)
        {
            _logger = logger;
            _feedingRelay = feedingRelay;
        }

        // GET /api/feedings
        [HttpGet]
        public async Task<ActionResult<IList<string>>> GetRecentFeedingsAsync()
        {
            // run process that will scan the log for feedings and return the last 10 feedings
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
                await _feedingRelay.PerformFeeding(feedingDto);
            
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