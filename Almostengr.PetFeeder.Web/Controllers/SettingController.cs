using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class Setting : BaseController
    {
        public Setting(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Settings";
            
            List<SettingViewModel> settings = await GetAsync<List<SettingViewModel>>("settings");

            return View(settings);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Title"] = "Edit Setting";

            SettingViewModel setting = await GetAsync<SettingViewModel>($"settings/edit/{id}");

            if (setting == null)
                return NotFound();

            return View(setting);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(SettingViewModel setting)
        {
            await UpdateAsync<SettingViewModel>($"settings/{setting.Id}", setting);
            return RedirectToAction("index");
        }

    }
}