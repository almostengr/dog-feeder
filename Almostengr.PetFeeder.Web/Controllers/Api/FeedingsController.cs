using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Relays;
using Almostengr.PetFeeder.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class FeedingsController : BaseApiController
    {
        private readonly ILogger<FeedingsController> _logger;
        private readonly IFeedingRepository _feedingRepository;
        private readonly IFoodBowlRelay _feedingRelay;

        public FeedingsController(ILogger<FeedingsController> logger, IFeedingRepository feedingRepository,
            IFoodBowlRelay feedingRelay) : base(logger)
        {
            _logger = logger;
            _feedingRepository = feedingRepository;
            _feedingRelay = feedingRelay;
        }

        [HttpGet]
        public async Task<ActionResult<IList<FeedingDto>>> GetRecentFeedingsAsync()
        {
            var feedings = await _feedingRepository.GetLatestAsync();
            return Ok(feedings);
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<FeedingDto>>> GetAllFeedingsAsync()
        {
            var feedings = await _feedingRepository.GetAllAsync();
            return Ok(feedings);
        }

        [HttpPost]
        public async Task<ActionResult<FeedingDto>> CreateFeedingAsync([FromBody] FeedingDto feedingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Feeding feeding = new Feeding();
                feeding.AssignFromDto(feedingDto);
                
                await _feedingRelay.PerformFeeding(feeding);

                await _feedingRepository.AddAsync(feeding);
                await _feedingRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }

            return StatusCode(201);
        }

    }
}