using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class FeedingController : BaseController
    {
        private readonly IFeedingClient _feedingClient;

        public FeedingController(ILogger<FeedingController> logger, 
            IFeedingClient feedingClient) :
            base(logger)
        {
            _feedingClient = feedingClient;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Feedings";

            var feedings = await _feedingClient.GetAllFeedingsAsync();

            return View(feedings);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Feedings";

            var feedings = await _feedingClient.GetLatestFeedingsAsync();

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

            await _feedingClient.CreateFeedingAsync(feedingDto);

            return RedirectToAction("index");
        }

    }
}
