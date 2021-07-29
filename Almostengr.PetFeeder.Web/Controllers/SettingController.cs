using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class SettingController : BaseController
    {
        public SettingController(ILogger<SettingController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Settings";
            
            var settings = await GetAsync<IList<SettingDto>>("api/settings");

            return View(settings);
        }

        [HttpGet("{id}/edit")]
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Title"] = "Edit Setting";

            var setting = await GetAsync<SettingDto>("api/settings/" + id);

            if (setting == null)
                return NotFound();

            return View(setting);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(SettingDto settingDto)
        {
            await PutAsync("api/settings/" + settingDto.Key, settingDto);
            return RedirectToAction("index");
        }

    }
}