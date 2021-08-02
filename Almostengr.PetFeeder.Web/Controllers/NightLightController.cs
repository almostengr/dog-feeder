using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class NightLightController : BaseController
    {
        private readonly INightLightClient _nightLightClient;

        public NightLightController(ILogger<BaseController> logger,
            INightLightClient nightLightClient) : base(logger)
        {
            _nightLightClient = nightLightClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNightLight(NightLightDto nightLightDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(nightLightDto);
            }

            await _nightLightClient.CreateNightLightAsync(nightLightDto);

            return RedirectToAction("index");
        }
    }
}