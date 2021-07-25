using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class PowerController : BaseController
    {
        public PowerController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> SystemShutDown()
        {
            await CreateAsync<PowerViewModel>("power/shutdown", new PowerViewModel());
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> SystemRestart()
        {
            await CreateAsync<PowerViewModel>("power/restart", new PowerViewModel());
            return RedirectToAction("Index", "Home");
        }
        
    }
}