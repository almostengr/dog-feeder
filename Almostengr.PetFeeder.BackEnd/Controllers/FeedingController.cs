using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public class FeedingController : BaseApiController
    {
        private readonly IFeedingService _service;

        public FeedingController(ILogger<FeedingController> logger, IFeedingService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedings()
        {
            var feedings = await _service.GetFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeeding(int id)
        {
            var feeding = await _service.GetFeedingAsync(id);
            return Ok(feeding);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeeding(FeedingDto feedingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            FeedingDto createdFeeding = await _service.CreateFeedingAsync(feedingDto);
            return CreatedAtRoute(nameof(GetFeeding), new { id = createdFeeding.FeedingId }, createdFeeding);
        }
    }
}