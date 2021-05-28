using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Relays;
using Almostengr.PetFeeder.Api.Repository;
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
        public async Task<ActionResult<IList<Feeding>>> GetRecentFeedingsAsync()
        {
            _logger.LogInformation("Getting recent feedings");

            var feedings = await _feedingRepository.GetRecentFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<Feeding>>> GetAllFeedingsAsync()
        {
            _logger.LogInformation("Getting all feedings");

            var feedings = await _feedingRepository.GetAllAsync();
            return Ok(feedings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feeding>> GetFeedingByIdAsync(int id)
        {
            _logger.LogInformation("Getting single feeding");

            var feeding = await _feedingRepository.GetByIdAsync(id);

            if (feeding != null)
            {
                return Ok(feeding);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Feeding>> CreateFeedingAsync(Feeding feeding)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _feedingRelay.PerformFeeding(feeding);

                await _feedingRepository.CreateAsync(feeding);
                await _feedingRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

            return StatusCode(201);
        }


    }
}