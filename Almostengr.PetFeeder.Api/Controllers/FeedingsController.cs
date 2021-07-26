using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Relays;
using Almostengr.PetFeeder.Api.Repository;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class FeedingsController : BaseController
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
            var feedings = await _feedingRepository.GetRecentFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<FeedingDto>>> GetAllFeedingsAsync()
        {
            var feedings = await _feedingRepository.GetAllAsync();
            return Ok(feedings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedingDto>> GetFeedingByIdAsync(int id)
        {
            var FeedingDto = await _feedingRepository.GetByIdAsync(id);

            if (FeedingDto != null)
            {
                return Ok(FeedingDto);
            }

            return NotFound();
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