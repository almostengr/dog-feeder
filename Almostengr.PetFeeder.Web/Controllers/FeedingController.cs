using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class FeedingController : BaseController
    {
        private readonly IFeedingClient _feedingClient;

        public FeedingController(ILogger<FeedingController> logger, IFeedingClient feedingClient) :
            base(logger)
        {
            _feedingClient = feedingClient;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Feedings";
            var feedings = await _feedingClient.GetAllFeedingsAsync();

            List<FeedingViewModel> feedingsViewModel = new List<FeedingViewModel>();
            foreach (var feeding in feedings)
            {
                feedingsViewModel.Add(new FeedingViewModel(feeding));
            }

            return View(feedingsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Feedings";
            var feedings = await _feedingClient.GetAllFeedingsAsync();

            IList<FeedingViewModel> feedingsViewModel = new List<FeedingViewModel>();
            foreach (var feeding in feedings)
            {
                feedingsViewModel.Add(new FeedingViewModel(feeding));
            }

            return View(feedingsViewModel);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeeding(FeedingViewModel model)
        {
            await _feedingClient.CreateFeedingAsync(model.FromViewModel());
            return RedirectToAction("index");
        }

    }
}
