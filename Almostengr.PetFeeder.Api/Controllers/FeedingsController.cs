using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class FeedingsController : BaseController
    {
        private readonly ILogger<FeedingsController> _logger;
        private readonly IFeedingRepository _repository;

        public FeedingsController(ILogger<FeedingsController> logger,  IFeedingRepository repository)
            :base(logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Feeding>>> GetRecentFeedingsAsync()
        {
            _logger.LogInformation("Getting recent feedings");

            var feedings = await _repository.GetRecentFeedingsAsync();
            return Ok(feedings);
        }
        
        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<Feeding>>> GetAllFeedingsAsync()
        {
            _logger.LogInformation("Getting all feedings");
            
            var feedings = await _repository.GetAllFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feeding>> GetFeedingByIdAsync(int? id)
        {
            _logger.LogInformation("Getting single feeding"); 

            var feeding = await _repository.GetFeedingByIdAsync(id);

            if (feeding != null)
            {
                return Ok(feeding);
            }

            return NotFound();
        }

    }
}