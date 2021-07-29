using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;
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

            var feedings = await GetAsync<IList<FeedingDto>>("api/feedings/all");

            return View(feedings);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Feedings";

            var feedings = await GetAsync<IList<FeedingDto>>("api/feedings");

            return View(feedings);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeeding(FeedingDto feedingDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(feedingDto);
            }

            await PostAsync<FeedingDto>("api/feedings", feedingDto);

            return RedirectToAction("index");
        }

    }
}
