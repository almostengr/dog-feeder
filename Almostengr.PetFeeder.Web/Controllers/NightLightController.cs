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
        public async Task<IActionResult> LightOn()
        {
            NightLightViewModel nightLightViewModel = new NightLightViewModel();
            nightLightViewModel = await CreateAsync<NightLightViewModel>("nightlight/on", nightLightViewModel);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> LightOff()
        {
            NightLightViewModel nightLightViewModel = new NightLightViewModel();
            nightLightViewModel = await CreateAsync<NightLightViewModel>("nightlight/off", nightLightViewModel);
            return RedirectToAction("index");
        }
    }
}