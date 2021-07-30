using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class AlarmController : BaseController
    {
        public AlarmController(ILogger<AlarmController> logger) :
            base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Feedings";

            var feedings = await GetAsync<IList<AlarmDto>>("api/alarms/all");

            return View(feedings);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Feedings";

            var feedings = await GetAsync<IList<AlarmDto>>("api/alarms");

            return View(feedings);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(AlarmDto alarmDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(alarmDto);
            }

            if (alarmDto.AlarmId > 0)
            {
                // existing record
                await PutAsync<AlarmDto>("/api/alarms/", alarmDto);
            }
            else
            {
                // new record
                await PostAsync<AlarmDto>("/api/alarms", alarmDto);
            }

            return RedirectToAction("index");
        }

    }
}
