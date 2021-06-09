using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Web.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> LatestFeeding()
        {
            List<FeedingViewModel> feedings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000");

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

            return PartialView("_LatestFeedings", feedings);
        }
    }
}
