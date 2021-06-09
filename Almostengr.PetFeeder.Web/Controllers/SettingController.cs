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

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Settings";
            
            List<SettingViewModel> settings = null;
            settings = await GetAsync<List<SettingViewModel>>("settings");

            return View(settings);
        }

        public async Task<IActionResult> EditSettings()
        {
            List<SettingViewModel> settings = null;
            settings = await GetAsync<List<SettingViewModel>>("settings");
            return View(settings);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSettings(List<SettingViewModel> settings)
        {
            await UpdateAsync<List<SettingViewModel>>("settings", settings);
            return RedirectToAction("index");
        }

    }
}