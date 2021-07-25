using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly IScheduleClient _scheduleClient;

        public ScheduleController(ILogger<ScheduleController> logger, IScheduleClient scheduleClient) : base(logger)
        {
            _scheduleClient = scheduleClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Scheduled Feeding";
            var schedules = await _scheduleClient.GetAllSchedulesAsync();

            List<ScheduleViewModel> models = new List<ScheduleViewModel>();
            foreach(var schedule in schedules)
            {
                models.Add(new ScheduleViewModel(schedule));
            }

            return View(models);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Delete Scheduled Feeding";

            await _scheduleClient.DeleteScheduleAsync(id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Scheduled Feeding";

            return View("CreateEdit", new ScheduleViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int scheduleId)
        {
            ViewData["Title"] = "Edit Scheduled Feeding";

            Schedule schedule = await _scheduleClient.GetScheduleAsync(scheduleId);            

            if (schedule == null)
                return NotFound();

            ScheduleViewModel model = new ScheduleViewModel(schedule);

            return View("CreateEdit", schedule);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(ScheduleViewModel schedule)
        {
            if (ModelState.IsValid == false)
            {
                return View(schedule);
            }

            if (schedule.Id > 0)
            {
                // existing record
                await _scheduleClient.CreateScheduleAsync(schedule.FromViewModel());
            }
            else
            {
                // new record
                await _scheduleClient.UpdateScheduleAsync(schedule.FromViewModel());
            }

            return RedirectToAction("index");
        }

    }
}