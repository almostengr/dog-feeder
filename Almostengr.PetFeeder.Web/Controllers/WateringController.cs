using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class WateringController : BaseController
    {
        private readonly ILogger<WateringController> _logger;
        private readonly IWateringClient _wateringClient;

        public WateringController(ILogger<WateringController> logger, IWateringClient wateringClient) : base(logger)
        {
            _logger = logger;
            _wateringClient = wateringClient;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Waterings";
            var waterings = await _wateringClient.GetAllWateringsAsync();

            IList<WateringViewModel> models = new List<WateringViewModel>();
            foreach(var watering in waterings)
            {
                models.Add(new WateringViewModel(watering));
            }

            return View(waterings);
        }
    
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Waterings";
            var waterings = await _wateringClient.GetRecentWateringsAsync();

            IList<WateringViewModel> models = new List<WateringViewModel>();
            foreach(var watering in waterings)
            {
                models.Add(new WateringViewModel(watering));
            }

            return View(waterings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatering(int id)
        {
            var watering = await _wateringClient.GetWateringAsync(id);

            if(watering == null)
            {
                return NotFound();
            }

            return View(new WateringViewModel(watering));
        }

    }
}
