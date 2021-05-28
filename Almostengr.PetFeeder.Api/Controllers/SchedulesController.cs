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
        private readonly IScheduleRepository _repository;

        public SchedulesController(ILogger<SchedulesController> logger, IScheduleRepository repository)
            : base(logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Schedule>>> GetAllSchedulesAsync()
        {
            _logger.LogInformation("Getting all schedules");

            var schedules = await _repository.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet, Route("active")]
        public async Task<ActionResult<IList<Schedule>>> GetActiveAsync()
        {
            _logger.LogInformation("Getting all active schedules");

            var schedules = await _repository.GetAllActiveSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet, Route("inactive")]
        public async Task<ActionResult<IList<Schedule>>> GetInactiveAsync()
        {
            _logger.LogInformation("Getting all inactive schedules");

            var schedules = await _repository.GetAllInactiveSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleByIdAsync(int id)
        {
            _logger.LogInformation("Getting single schedule");

            var schedule = await _repository.GetByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }
            
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> CreateScheduleAsync(Schedule schedule)
        {
            _logger.LogInformation("Creating schedule");

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repository.CreateAsync(schedule);
                await _repository.SaveChangesAsync();
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
            _logger.LogInformation("Deleting schedule");

            Schedule existingSchedule = await _repository.GetByIdAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            try
            {
                _repository.Delete(existingSchedule);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateScheduleAsync(int id, Schedule schedule)
        {
            _logger.LogInformation("Updating schedule");

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Schedule existingSchedule = await _repository.GetByIdAsync(id);

            if (existingSchedule == null)
            {
                return NotFound();
            }

            try
            {
                _repository.Update(schedule);
                await _repository.SaveChangesAsync();
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
