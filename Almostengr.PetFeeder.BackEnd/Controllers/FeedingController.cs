using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services;
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
            List<FeedingDto> feedingDtos = await _service.GetFeedingsAsync();
            return Ok(feedingDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeeding(int id)
        {
            FeedingDto feedingDto = await _service.GetFeedingAsync(id);

            if (feedingDto == null)
            {
                return NotFound();
            }

            return Ok(feedingDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeeding(FeedingDto feedingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            FeedingDto createdFeedingDto = await _service.CreateFeedingAsync(feedingDto);

            return CreatedAtAction(nameof(GetFeeding), new { id = createdFeedingDto.FeedingId }, createdFeedingDto);
        }
    }
}