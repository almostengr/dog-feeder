using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class FeedingController : BaseController
    {
        public FeedingController(ILogger<FeedingController> logger) :
            base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Feedings";
            List<FeedingViewModel> feedings = await GetAsync<List<FeedingViewModel>>("feedings/all");
            return View(feedings);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Feedings";
            List<FeedingViewModel> feedings = await GetAsync<List<FeedingViewModel>>("feedings");
            return View(feedings);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeeding(FeedingViewModel feedingViewModel)
        {
            FeedingViewModel responseFeeding = await CreateAsync<FeedingViewModel>("feedings", feedingViewModel);
            return RedirectToAction("index");
        }

    }
}
