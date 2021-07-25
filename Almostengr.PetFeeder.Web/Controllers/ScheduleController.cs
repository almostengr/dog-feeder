using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        public ScheduleController(ILogger<ScheduleController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Scheduled Feeding";

            List<ScheduleViewModel> schedules = await GetAsync<List<ScheduleViewModel>>("schedules");

            return View(schedules);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Delete Scheduled Feeding";

            await DeleteAsync<ScheduleViewModel>($"schedules/{id}");

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

            ScheduleViewModel schedule = await GetAsync<ScheduleViewModel>($"schedules/{scheduleId}");

            if (schedule == null)
                return NotFound();

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
                await CreateAsync<ScheduleViewModel>("schedules", schedule); // existing record
            }
            else
            {
                await UpdateAsync<ScheduleViewModel>($"schedules/${schedule.Id}", schedule); // new record
            }

            return RedirectToAction("index");
        }

    }
}