using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class WateringController : BaseController
    {
        private readonly ILogger<WateringController> _logger;

        public WateringController(ILogger<WateringController> logger) : base(logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Waterings";
            List<WateringViewModel> waterings = null;

            waterings = await GetAsync<List<WateringViewModel>>("waterings/all");

            return View(waterings);
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Waterings";
            List<WateringViewModel> waterings = null;

            waterings = await GetAsync<List<WateringViewModel>>("waterings");

            return View(waterings);
        }

    }
}
