using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(ILogger<ScheduleController> logger) : base(logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Scheduled Feeding";
            List<ScheduleViewModel> schedules = null;

            schedules = await GetAsync<List<ScheduleViewModel>>("schedules");

            return View(schedules);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            ViewData["Title"] = "Delete Scheduled Feeding";

            ScheduleViewModel schedule = null;
            schedule = await DeleteAsync<ScheduleViewModel>($"schedules/{id}");

            return RedirectToAction("index");
        }

        public async Task<IActionResult> CreateSchedule()
        {
            ViewData["Title"] = "Create Scheduled Feeding";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule(ScheduleViewModel schedule)
        {
            ScheduleViewModel responseSchedule = null;
            responseSchedule = await CreateAsync<ScheduleViewModel>("schedules", schedule);
            return View(responseSchedule);
        }

        public async Task<IActionResult> UpdateSchedule(int id)
        {
            ScheduleViewModel schedule = null;
            schedule = await GetAsync<ScheduleViewModel>($"schedules/{id}");
            return View(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSchedule(ScheduleViewModel schedule)
        {
            ScheduleViewModel responseSchedule = new ScheduleViewModel();
            responseSchedule = await UpdateAsync<ScheduleViewModel>($"schedule/${schedule.Id}", schedule);
            return View(responseSchedule);
        }
    }
}