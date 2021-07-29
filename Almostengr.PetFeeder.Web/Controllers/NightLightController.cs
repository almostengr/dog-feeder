using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;
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
        public async Task<IActionResult> CreateNightLight(NightLightDto nightLightDto)
        {
            // await _nightLightClient.CreateNightLightAsync(model.FromViewModel());
            await PostAsync<NightLightDto>("/api/nightlight", nightLightDto);
            return RedirectToAction("index");
        }
    }
}