using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Data;
using Almostengr.DogFeeder.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Api.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IScheduleRepository _repository;

        public ScheduleController(ILogger<ScheduleController> logger, IScheduleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Schedule>>> GetAsync()
        {
            var schedules = await _repository.GetAllSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet]
        public async Task<ActionResult<Schedule>> GetAsync(int id)
        {
            var schedule = await _repository.GetScheduleAsync(id);

            if (schedule != null)
            {
                return Ok(schedule);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> PostAsync(Schedule model)
        {
            await _repository.CreateSchedule(model);
            await _repository.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetAsync), new { Id = model.Id, model });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingSchedule = await _repository.GetScheduleAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            _repository.DeleteSchedule(existingSchedule);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Schedule schedule)
        {
            var existingSchedule = await _repository.GetScheduleAsync(schedule.Id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            // await _repository.Update(schedule);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}