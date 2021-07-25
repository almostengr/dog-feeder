using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class PowerController : BaseController
    {
        private readonly IPowerClient _powerClient;

        public PowerController(ILogger<BaseController> logger, IPowerClient powerClient) : base(logger)
        {
            _powerClient = powerClient;
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> SystemShutDown()
        {
            await _powerClient.ShutDown();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> SystemRestart()
        {
            await _powerClient.Restart();
            return RedirectToAction("Index", "Home");
        }
        
    }
}