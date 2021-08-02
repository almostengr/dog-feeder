using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class WateringController : BaseController
    {
        private readonly IWateringClient _wateringClient;

        public WateringController(ILogger<WateringController> logger,
            IWateringClient wateringClient) : base(logger)
        {
            _wateringClient = wateringClient;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Waterings";
            var result = await _wateringClient.GetAllWateringsAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Waterings";
            var waterings = await _wateringClient.GetLatestWateringsAsync();
            return View(waterings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatering(int id)
        {
            var watering = await _wateringClient.GetWateringAsync(id);

            if (watering == null)
            {
                return View();
            }

            return View(watering);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdateWatering([FromBody] WateringDto wateringDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(wateringDto);
            }

            await _wateringClient.CreateWateringAsync(wateringDto);
            
            return RedirectToAction("Index");
        }

    }
}
