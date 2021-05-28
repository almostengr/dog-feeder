using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class NightLightController : BaseController
    {
        public NightLightController(ILogger<BaseController> logger, AppSettings appSettings) : base(logger, appSettings)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}