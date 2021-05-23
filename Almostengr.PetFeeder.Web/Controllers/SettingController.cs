using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class Setting : BaseController
    {
        private readonly AppSettings _appSettings;

        public Setting(ILogger<BaseController> logger, AppSettings appSettings) : base(logger, appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Settings";
            List<SettingViewModel> settings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;
                var response = await client.GetAsync("settings");

                if (response.IsSuccessStatusCode)
                {
                    settings = JsonConvert.DeserializeObject<List<SettingViewModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    settings = new List<SettingViewModel>();
                }
            }

            return View(settings);
        }

        public async Task<IActionResult> Edit()
        {
            ViewData["Title"] = "Edit Setting";
            SettingViewModel setting = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;
                var response = await client.GetAsync("settings/{key}");

                if (response.IsSuccessStatusCode)
                {
                    setting = JsonConvert.DeserializeObject<SettingViewModel>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    setting = new SettingViewModel();
                }
            }

            return View(setting);
        }

    }
}