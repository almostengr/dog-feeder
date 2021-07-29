using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;
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
            ViewData["Title"] = "Scheduled Feedings";
            var schedules = await GetAsync<IList<ScheduleDto>>("/api/schedules");

            return View(schedules);
        }

        [HttpPost("{id}")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Delete Scheduled Feeding";

            await DeleteAsync<ScheduleDto>("/api/schedules/" + id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Scheduled Feeding";

            return View("CreateEdit", new ScheduleDto());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int scheduleId)
        {
            ViewData["Title"] = "Edit Scheduled Feeding";

            ScheduleDto scheduleDto = await GetAsync<ScheduleDto>("/api/schedules/" + scheduleId);

            if (scheduleDto == null)
                return NotFound();

            return View("CreateEdit", scheduleDto);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(ScheduleDto scheduleDto)
        {
            if (ModelState.IsValid == false)
            {
                return View(scheduleDto);
            }

            if (scheduleDto.ScheduleId > 0)
            {
                // existing record
                await PutAsync<ScheduleDto>("/api/schedules/", scheduleDto);
            }
            else
            {
                // new record
                await PostAsync<ScheduleDto>("/api/schedules", scheduleDto);
            }

            return RedirectToAction("index");
        }

    }
}