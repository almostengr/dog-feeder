using System.Collections.Generic;
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

        public ScheduleController(ILogger<BaseApiController> logger,
            IScheduleService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            List<ScheduleDto> schedules = await _service.GetAllSchedules();
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
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return BadRequest();
            }

            ScheduleDto createResponse = await _service.CreateScheduleAsync(scheduleDto);
            return Ok(createResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchedule([FromBody] ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return BadRequest();
            }

            var getResponse = await _service.GetScheduleAsync(scheduleDto.ScheduleId);
            if (getResponse == null)
            {
                return NotFound();
            }

            ScheduleDto updateResponse = await _service.UpdateScheduleAsync(scheduleDto);
            return Ok(updateResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var getResponse = await _service.GetScheduleAsync(id);
            if (getResponse == null)
            {
                return NotFound();
            }

            await _service.DeleteScheduleAsync(id);
            return NoContent();
        }

    }
}