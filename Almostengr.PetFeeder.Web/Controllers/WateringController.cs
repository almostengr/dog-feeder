using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class WateringController : BaseController
    {
        private readonly ILogger<WateringController> _logger;
        private readonly AppSettings _appSettings;

        public WateringController(ILogger<WateringController> logger, AppSettings appSettings) :
            base(logger, appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Waterings";
            List<WateringViewModel> feedings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;

                var response = await client.GetAsync("waterings/all");

                if (response.IsSuccessStatusCode)
                {
                    feedings = JsonConvert.DeserializeObject<List<WateringViewModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    feedings = new List<WateringViewModel>();
                }
            }

            return View(feedings);
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Waterings";
            List<WateringViewModel> feedings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;
                var response = await client.GetAsync("waterings");

                if (response.IsSuccessStatusCode)
                {
                    feedings = JsonConvert.DeserializeObject<List<WateringViewModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    feedings = new List<WateringViewModel>();
                }
            }

            return View(feedings);
        }

    }
}
