using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        public ScheduleController(ILogger<ScheduleController> logger, HttpClient httpClient, AppSettings appSettings) : 
            base(logger, httpClient, appSettings)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}