using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Web.Controllers
{
    public class SettingsController : BaseController
    {
        public SettingsController(ILogger<SettingsController> logger, HttpClient httpClient, AppSettings appSettings) : 
            base(logger, httpClient, appSettings)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}