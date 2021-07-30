using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Repository;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Almostengr.PetFeeder.Web.Constants;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class SchedulesController : BaseApiController
    {
        private readonly ILogger<SchedulesController> _logger;
        private readonly IScheduleRepository _scheduleRepository;

        public SchedulesController(ILogger<SchedulesController> logger,
            IScheduleRepository scheduleRepository)
            : base(logger)
        {
            _logger = logger;
            _scheduleRepository = scheduleRepository;
        }

        // GET /api/schedules/all
        [HttpGet("all")]
        public async Task<ActionResult<IList<ScheduleDto>>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();

            return Ok(schedules.Select(s => s.AssignToDto()).ToList());
        }

        // GET /api/schedules
        [HttpGet]
        public async Task<ActionResult<IList<ScheduleDto>>> GetActiveSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllActiveSchedulesAsync();

            return Ok(schedules.Select(s => s.AssignToDto()).ToList());
        }

        // GET /api/schedules/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetScheduleByIdAsync(int id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule.AssignToDto());
        }

        // POST /api/schedules
        [HttpPost]
        public async Task<ActionResult<ScheduleDto>> CreateScheduleAsync([FromBody] ScheduleDto scheduleDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Schedule schedule = new Schedule();
                schedule.CreateFromDto(scheduleDto);

                await _scheduleRepository.AddAsync(schedule);
                await _scheduleRepository.SaveChangesAsync();

                // return StatusCode(201);
                return CreatedAtAction(nameof(GetScheduleByIdAsync), new { id = schedule.ScheduleId }, schedule.AssignToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

        // DELETE /api/schedules/{id}        
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
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

        // PUT /api/schedules
        [HttpPut]
        public async Task<ActionResult> UpdateScheduleAsync([FromBody] ScheduleDto scheduleDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var existingSchedule = await _scheduleRepository.GetByIdAsync(scheduleDto.ScheduleId);

            if (existingSchedule == null)
            {
                return NotFound();
            }

            try
            {
                Schedule schedule = new Schedule();
                schedule.CreateFromDto(scheduleDto);

                _scheduleRepository.Update(schedule);
                await _scheduleRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

    }
}
