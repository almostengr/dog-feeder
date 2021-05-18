using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        public ScheduleController(ILogger<BaseController> logger, HttpClient httpClient) : 
            base(logger, httpClient)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}