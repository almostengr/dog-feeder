using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Web.Controllers
{
    public class SettingsController : Controller
    {
        public SettingsController(ILogger<SettingsController> logger,  AppSettings appSettings) 
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}