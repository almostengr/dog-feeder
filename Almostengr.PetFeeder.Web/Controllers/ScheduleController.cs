using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly IScheduleClient _scheduleClient;

        public ScheduleController(ILogger<ScheduleController> logger,   
            IScheduleClient scheduleClient) : base(logger)
        {
            _scheduleClient = scheduleClient;
        }

        // GET /schedule
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Scheduled Feedings";
            var schedules = await _scheduleClient.GetAllSchedulesAsync();

            return View(schedules);
        }

        // POST /schedule/delete/{id}
        [HttpPost("{id}")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Delete Scheduled Feeding";

            await _scheduleClient.DeleteScheduleAsync(id);

            return RedirectToAction("index");
        }

        // GET /schedule/create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Scheduled Feeding";

            return View("CreateEdit", new ScheduleDto());
        }

        // GET /schedule/{id}/edit
        [HttpGet]
        public async Task<IActionResult> Edit(int scheduleId)
        {
            ViewData["Title"] = "Edit Scheduled Feeding";

            ScheduleDto scheduleDto = await _scheduleClient.GetScheduleAsync(scheduleId);

            if (scheduleDto == null)
                return NotFound();

            return View("CreateEdit", scheduleDto);
        }

        // POST /schedule/{id}/createupdate
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
                await _scheduleClient.UpdateScheduleAsync(scheduleDto); 
            }
            else
            {
                // new record
                await _scheduleClient.CreateScheduleAsync(scheduleDto);
            }

            return RedirectToAction("index");
        }

    }
}