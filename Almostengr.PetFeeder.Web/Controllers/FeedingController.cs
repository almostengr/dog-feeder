using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class FeedingController : BaseController
    {
        private readonly ILogger<FeedingController> _logger;
        private readonly AppSettings _appSettings;

        public FeedingController(ILogger<FeedingController> logger, AppSettings appSettings) :
            base(logger, appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Feedings";
            List<FeedingViewModel> feedings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;
                var response = await client.GetAsync("feedings/all");

                if (response.IsSuccessStatusCode)
                {
                    feedings = JsonConvert.DeserializeObject<List<FeedingViewModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    feedings = new List<FeedingViewModel>();
                }
            }

            return View(feedings);
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Feedings";
            List<FeedingViewModel> feedings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;
                var response = await client.GetAsync("feedings");

                if (response.IsSuccessStatusCode)
                {
                    feedings = JsonConvert.DeserializeObject<List<FeedingViewModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    feedings = new List<FeedingViewModel>();
                }
            }

            return View(feedings);
        }

    }
}
