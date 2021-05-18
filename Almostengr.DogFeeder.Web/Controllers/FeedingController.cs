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

        public FeedingController(ILogger<BaseController> logger, HttpClient httpClient) : base(logger, httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            List<FeedingViewModel> feedings = new List<FeedingViewModel>();
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:44337/feedings");

            if (response.IsSuccessStatusCode){
                feedings = JsonConvert.DeserializeObject<List<FeedingViewModel>>(response.Content.ReadAsStringAsync().Result);
            }

            return View(feedings);
        }
    }
}