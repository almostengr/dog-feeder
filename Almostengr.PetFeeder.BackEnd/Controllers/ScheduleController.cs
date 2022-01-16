using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public class ScheduleController : BaseApiController, IScheduleController
    {
        private readonly IScheduleService _service;

        public ScheduleController(ILogger<ScheduleController> logger, IScheduleService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            List<ScheduleDto> schedules = await _service.GetSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            ScheduleDto schedule = await _service.GetScheduleAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule(ScheduleDto scheduleDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            ScheduleDto createdSchedule = await _service.CreateScheduleAsync(scheduleDto);

            return CreatedAtAction(nameof(GetSchedule), new { id = createdSchedule.ScheduleId }, createdSchedule);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchedule(ScheduleDto schedule)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            ScheduleDto updatedSchedule = await _service.UpdateScheduleAsync(schedule);

            return Ok(updatedSchedule);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var scheduleDto = await _service.GetScheduleAsync(id);

            if (scheduleDto == null)
            {
                return NotFound();
            }
            
            bool isDeleted = await _service.DeleteScheduleAsync(id);

            if (isDeleted == false)
            {
                return StatusCode(500, "Failed to delete schedule");
            }

            return NoContent();
        }

    }
}