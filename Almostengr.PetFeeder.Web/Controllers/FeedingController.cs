using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class FeedingController : BaseController
    {
        private readonly ILogger<FeedingController> _logger;

        public FeedingController(ILogger<FeedingController> logger) :
            base(logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Feedings";
            List<FeedingViewModel> feedings = null;

            feedings = await GetAsync<List<FeedingViewModel>>("feedings/all");

            return View(feedings);
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Feedings";
            List<FeedingViewModel> feedings = null;

            feedings = await GetAsync<List<FeedingViewModel>>("feedings");

            return View(feedings);
        }

        public async Task<IActionResult> GetFeedingById(int id)
        {
            FeedingViewModel feeding = null;

            feeding = await GetAsync<FeedingViewModel>($"feedings/{id}");

            return View(feeding);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeeding(FeedingViewModel feedingViewModel)
        {
            FeedingViewModel responseFeeding = null;
            responseFeeding = await CreateAsync<FeedingViewModel>("feedings", feedingViewModel);
            // return View(responseFeeding);
            return RedirectToAction("index");
        }

    }
}
