using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.FrontEnd.Controllers
{
    public class NightLightController : BaseController
    {
        public NightLightController(ILogger<NightLightController> logger): base(logger)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> TurnOn(NightLightDto nightLightDto)
        {
            await PostAsync("/api/nightlight", nightLightDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TurnOff(NightLightDto nightLightDto)
        {
            await PostAsync("/api/nightlight", nightLightDto);
            return RedirectToAction("Index");
        }
    }
}