using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class SchedulesController : BaseController
    {
        private readonly ILogger<SchedulesController> _logger;
        private readonly IScheduleRepository _scheduleRepository;

        public SchedulesController(ILogger<SchedulesController> logger, IScheduleRepository scheduleRepository)
            : base(logger)
        {
            _logger = logger;
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IList<Schedule>>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet]
        public async Task<ActionResult<IList<Schedule>>> GetActiveSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllActiveSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet, Route("inactive")]
        public async Task<ActionResult<IList<Schedule>>> GetInactiveAsync()
        {
            var schedules = await _scheduleRepository.GetAllInactiveSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleByIdAsync(int id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }
            
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> CreateScheduleAsync([FromBody] Schedule schedule)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _scheduleRepository.CreateAsync(schedule);
                await _scheduleRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteScheduleAsync(int id)
        {
            Schedule existingSchedule = await _scheduleRepository.GetByIdAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            try
            {
                _scheduleRepository.Delete(existingSchedule);
                await _scheduleRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateScheduleAsync(int id, [FromBody] Schedule schedule)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Schedule existingSchedule = await _scheduleRepository.GetByIdAsync(id);

            if (existingSchedule == null)
            {
                return NotFound();
            }

            try
            {
                _scheduleRepository.Update(schedule);
                await _scheduleRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }

            return NoContent();
        }
    }
}
