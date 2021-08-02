using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class SettingController : BaseController
    {
        private readonly ISettingClient _settingClient;

        public SettingController(ILogger<SettingController> logger,
            ISettingClient settingClient) : base(logger)
        {
            _settingClient = settingClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Settings";

            var settings = await _settingClient.GetSettingsAsync();

            return View(settings);
        }

        [HttpGet("{id}/edit")]
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Title"] = "Edit Setting";

            var setting = await _settingClient.GetSettingAsync(id);

            if (setting == null)
                return NotFound();

            return View(setting);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(SettingDto settingDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(settingDto);
            }

            await _settingClient.UpdateSettingAsync(settingDto);

            return RedirectToAction("index");
        }

    }
}