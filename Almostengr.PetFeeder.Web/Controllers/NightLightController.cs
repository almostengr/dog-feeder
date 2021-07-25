using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class NightLightController : BaseController
    {
        public NightLightController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> LightOff()
        {
            await CreateAsync<NightLightViewModel>("nightlight/off", new NightLightViewModel());
            return RedirectToAction("index");
        }
    }
}