using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Repository;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet("all")]
        public async Task<ActionResult<IList<ScheduleDto>>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();
            var schedulesDto = new List<ScheduleDto>();

            foreach (var schedule in schedules)
            {
                schedulesDto.Add(schedule.AssignToDto());
            }

            return Ok(schedulesDto);
        }

        [HttpGet]
        public async Task<ActionResult<IList<ScheduleDto>>> GetActiveSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllActiveSchedulesAsync();
            var schedulesDto = new List<ScheduleDto>();

            foreach (var schedule in schedules)
            {
                schedulesDto.Add(schedule.AssignToDto());
            }

            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetScheduleByIdAsync(int id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            ScheduleDto scheduleDto = schedule.AssignToDto();

            return Ok(scheduleDto);
        }

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
                schedule.AssignFromDto(scheduleDto);

                await _scheduleRepository.AddAsync(schedule);
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
                schedule.AssignFromDto(scheduleDto);

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
