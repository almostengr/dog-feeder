using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Data;
using Almostengr.DogFeeder.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Api.Controllers
{
    public class SchedulesController : BaseController
    {
        private readonly ILogger<SchedulesController> _logger;
        private readonly IScheduleRepository _repository;

        public SchedulesController(ILogger<SchedulesController> logger, IScheduleRepository repository)
            :base(logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Schedule>>> GetAsync()
        {
            _logger.LogInformation("Getting all schedules");

            var schedules = await _repository.GetAllSchedulesAsync();
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
        public async Task<ActionResult<Schedule>> GetAsync(int id)
        {
            _logger.LogInformation("Getting single schedule");

            var schedule = await _repository.GetScheduleByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> PostAsync(Schedule model)
        {
            _logger.LogInformation("Creating schedule");

            var schedule = await _repository.CreateSchedule(model);
            await _repository.SaveChangesAsync();

            return CreatedAtRoute(nameof(schedule), new {Id = schedule.Id}, schedule);
            // return CreatedAtRoute(nameof(GetAsync), new { Id = model.Id, model });
//             return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting schedule");
            
            var existingSchedule = await _repository.GetScheduleByIdAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            _repository.DeleteSchedule(existingSchedule);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}"]
        public async Task<ActionResult> UpdateAsync(int id, Schedule schedule)
        {
            _logger.LogInformation("Updating schedule");

            var existingSchedule = await _repository.GetScheduleByIdAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            _repository.UpdateSchedule(schedule);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
