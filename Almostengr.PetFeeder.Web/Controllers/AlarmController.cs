using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class AlarmController : BaseController
    {
        private readonly IAlarmClient _alarmClient;

        public AlarmController(ILogger<AlarmController> logger, IAlarmClient alarmClient):
            base(logger)
        {
            _alarmClient = alarmClient;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "All Alarms";

            var feedings = await _alarmClient.GetAllAlarmsAsync();

            return View(feedings);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Latest Alarms";

            var feedings = await _alarmClient.GetActiveAlarmsAsync();

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
                await _alarmClient.UpdateAlarmAsync(alarmDto); // existing record
            }
            else
            {
                await _alarmClient.CreateAlarmAsync(alarmDto); // new record
            }

            return RedirectToAction("index");
        }

    }
}
