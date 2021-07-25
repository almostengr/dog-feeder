using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class Setting : BaseController
    {
        private readonly ISettingClient _settingClient;

        public Setting(ILogger<BaseController> logger, ISettingClient settingClient) : base(logger)
        {
            _settingClient = settingClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Settings";
            
            var settings = await _settingClient.GetSettingsAsync();

            IList<SettingViewModel> models = new List<SettingViewModel>();
            foreach(var setting in settings)
            {
                models.Add(new SettingViewModel(setting));
            }

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Title"] = "Edit Setting";

            var setting = await _settingClient.GetSettingAsync(id);

            if (setting == null)
                return NotFound();

            SettingViewModel settingViewModel = new SettingViewModel(setting);

            return View(settingViewModel);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(SettingViewModel model)
        {
            await _settingClient.UpdateSettingAsync(model.FromViewModel());
            return RedirectToAction("index");
        }

    }
}