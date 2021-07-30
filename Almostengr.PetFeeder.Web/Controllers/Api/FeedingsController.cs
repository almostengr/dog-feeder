using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Relays;
using Almostengr.PetFeeder.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using System.Linq;
using Almostengr.PetFeeder.Web.Constants;

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

        // GET /api/feedings
        [HttpGet]
        public async Task<ActionResult<IList<FeedingDto>>> GetRecentFeedingsAsync()
        {
            var feedings = await _feedingRepository.GetLatestAsync();
                        
            return Ok(feedings.Select(f => f.AssignToDto()).ToList());
        }

        // GET /api/feedings/all
        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<FeedingDto>>> GetAllFeedingsAsync()
        {
            var feedings = await _feedingRepository.GetAllAsync();
                        
            return Ok(feedings.Select(f => f.AssignToDto()).ToList());
        }

        // POST /api/feedings
        [HttpPost]
        public async Task<ActionResult<FeedingDto>> CreateFeedingAsync([FromBody] FeedingDto feedingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Feeding feeding = new Feeding();
            try
            {
                feeding.CreateFromDto(feedingDto);
                
                await _feedingRelay.PerformFeeding(feeding);

                await _feedingRepository.AddAsync(feeding);
                await _feedingRepository.SaveChangesAsync();
            
                // return StatusCode(201);
                return CreatedAtAction(nameof(GetFeedingByIdAsync), new { id = feeding.FeedingId }, feeding.AssignToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

        // GET /api/feedings/{id}
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<FeedingDto>> GetFeedingByIdAsync(int id)
        {
            var feeding = await _feedingRepository.GetByIdAsync(id);

            if (feeding == null)
            {
                return NotFound();
            }

            return Ok(feeding.AssignToDto());
        }

    }
}
