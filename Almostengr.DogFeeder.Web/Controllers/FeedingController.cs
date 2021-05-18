using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.DogFeeder.Web.Controllers
{
    public class FeedingController : BaseController
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FeedingController> _logger;

        public FeedingController(ILogger<FeedingController> logger, HttpClient httpClient, AppSettings appSettings) : 
            base(logger, httpClient, appSettings)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // List<FeedingViewModel> feedings = new List<FeedingViewModel>();
            // HttpResponseMessage response = await _httpClient.GetAsync("feedings");

            // if (response.IsSuccessStatusCode){
            //     feedings = JsonConvert.DeserializeObject<List<FeedingViewModel>>(response.Content.ReadAsStringAsync().Result);
            // }

            // return View(feedings);

            using(HttpClient client = new HttpClient())
            {
                // StringContent content= new StringContent(JsonConvert.SerializeObject)
                using (var response = await client.GetAsync("http://localhost:5002/feedings"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var feedings = JsonConvert.SerializeObject(response.Content.ReadAsStringAsync().Result);

                        return View(feedings);
                    }
                    else {
                        _logger.LogError("Error " + response.StatusCode.ToString());
                        return View();
                    }
                }
            }
        }

        
    }
}