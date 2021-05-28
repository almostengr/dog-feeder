using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class NightLightController : BaseController
    {
        public NightLightController(ILogger<BaseController> logger, AppSettings appSettings) : base(logger, appSettings)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}