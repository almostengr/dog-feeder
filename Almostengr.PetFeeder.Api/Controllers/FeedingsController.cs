using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
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
        public async Task<ActionResult<IList<Feeding>>> GetAsync()
        {
            _logger.LogInformation("Getting all feedings");
            
            var feedings = await _repository.GetAllFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feeding>> GetAsync(int id)
        {
            _logger.LogInformation("Getting single feeding"); 

            var feeding = await _repository.GetFeedingAsync(id);

            if (feeding != null)
            {
                return Ok(feeding);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Feeding>> PostAsync(Feeding model)
        {
            _logger.LogInformation("Posting feeding");

            try
            {
                await _repository.CreateFeeding(model);
                await _repository.SaveChangesAsync();

                return CreatedAtRoute(nameof(GetAsync), new { Id = model.Id, model });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
    }
}