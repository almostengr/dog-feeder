using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class NightLightController : BaseController
    {
        private readonly INightLightClient _nightLightClient;

        public NightLightController(ILogger<BaseController> logger, INightLightClient nightLightClient) : base(logger)
        {
            _nightLightClient = nightLightClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNightLight(NightLightViewModel model)
        {
            await _nightLightClient.CreateNightLightAsync(model.FromViewModel());
            return RedirectToAction("index");
        }
    }
}