using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class WateringController : BaseController
    {
        public WateringController(ILogger<WateringController> logger) : base(logger)
        {
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Waterings";
            var result = await GetAsync<IList<WateringDto>>("/api/waterings/all");
            return View(result);
        }
    
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Waterings";
            var waterings = await GetAsync<IList<WateringDto>>("/api/waterings");
            return View(waterings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatering(int id)
        {
            var watering = await GetAsync<WateringDto>("/api/waterings/{id}");

            if(watering == null)
            {
                return NotFound();
            }

            return View(new WateringViewModel(watering));
        }

        [HttpPost]
        public async Task<IActionResult> PostWatering([FromBody] WateringDto wateringDto)
        {
            if(ModelState.IsValid == false)
            {
                return View(wateringDto);
            }

            await PostAsync("/api/waterings", wateringDto);
            return RedirectToAction("Index");
        }

    }
}
