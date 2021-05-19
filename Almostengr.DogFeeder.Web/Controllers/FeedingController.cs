using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.DogFeeder.Web.Controllers
{
    public class FeedingController : Controller
    {
        private readonly ILogger<FeedingController> _logger;
        private readonly AppSettings _appSettings;

        public FeedingController(ILogger<FeedingController> logger,  AppSettings appSettings) 
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> Index()
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
                else{
                    feedings = new List<FeedingViewModel>();
                }
            }

            return View(feedings);
        }

        // public async Task<IActionResult> Create(Feeding feeding)
        // {
            

        //     // return RedirectToPage()
        // }

    }
}
