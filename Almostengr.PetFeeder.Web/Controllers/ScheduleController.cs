using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly AppSettings _appSettings;

        public ScheduleController(ILogger<ScheduleController> logger, AppSettings appSettings) : base(logger, appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> Index()
        {
            List<ScheduleViewModel> schedules = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;
                var response = await client.GetAsync("schedules");

                if (response.IsSuccessStatusCode)
                {
                    schedules = JsonConvert.DeserializeObject<List<ScheduleViewModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    schedules = new List<ScheduleViewModel>();
                }
            }

            return View(schedules);
        }
    }
}