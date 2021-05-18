using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Data;
using Almostengr.DogFeeder.Api.Models;
using Almostengr.DogFeeder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Api.Controllers
{
    public class FeedingController : ControllerBase
    {
        private readonly ILogger<FeedingController> _logger;
        private readonly AppSettings _appSettings;
        private readonly IFeedingRepository _repository;

        public FeedingController(ILogger<FeedingController> logger, AppSettings appSettings, IFeedingRepository repository)
        {
            _logger = logger;
            _appSettings = appSettings;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Feeding>>> GetAsync()
        {
            var feedings = await _repository.GetAllFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet]
        public async Task<ActionResult<Feeding>> GetAsync(int id)
        {
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