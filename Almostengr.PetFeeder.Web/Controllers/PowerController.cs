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
        public async Task<IActionResult> SystemShutDown()
        {
            PowerViewModel powerViewModel = new PowerViewModel();
            await CreateAsync<PowerViewModel>("power/shutdown", powerViewModel);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SystemRestart()
        {
            PowerViewModel powerViewModel = new PowerViewModel();
            await CreateAsync<PowerViewModel>("power/restart", powerViewModel);
            return View();
        }
        
    }
}