using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class PowerController : BaseController
    {
        private readonly IPowerClient _powerClient;

        public PowerController(ILogger<BaseController> logger, 
            IPowerClient powerClient) : base(logger)
        {
            _powerClient = powerClient;
        }

        // POST /power/
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(PowerDto powerDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(powerDto);
            }

            await _powerClient.PostAsync(powerDto);

            return RedirectToAction("index");
        }
    }
}