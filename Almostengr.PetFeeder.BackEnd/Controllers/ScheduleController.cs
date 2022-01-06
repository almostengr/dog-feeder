using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public class ScheduleController : BaseApiController
    {
        private readonly IScheduleService _service;

        public ScheduleController(ILogger<BaseApiController> logger, IScheduleService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            var schedules = await _service.GetSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var schedule = await _service.GetScheduleAsync(id);
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule(ScheduleDto scheduleDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var createdSchedule = await _service.CreateScheduleAsync(scheduleDto);
            return CreatedAtRoute(nameof(GetSchedule), new { id = createdSchedule.ScheduleId }, createdSchedule);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchedule(ScheduleDto schedule)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var updatedSchedule = await _service.UpdateScheduleAsync(schedule);
            return Ok(updatedSchedule);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await _service.DeleteScheduleAsync(id);
            return NoContent();
        }

    }
}