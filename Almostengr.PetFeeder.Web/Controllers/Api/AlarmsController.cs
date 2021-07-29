using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class AlarmsController : BaseApiController
    {
        private readonly IAlarmRepository _alarmRepo;
        private readonly ILogger<AlarmsController> _logger;

        public AlarmsController(ILogger<AlarmsController> logger, IAlarmRepository alarmRepo) : base(logger)
        {
            _alarmRepo = alarmRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IList<AlarmDto>>> GetActiveAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetActiveAlarmsAsync();
            var alarmsDto = new List<AlarmDto>();

            foreach (var alarm in alarms)
            {
                alarmsDto.Add(alarm.AssignToDto());
            }

            return Ok(alarmsDto);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IList<AlarmDto>>> GetAllAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetAllAsync();
            var alarmsDto = new List<AlarmDto>();

            foreach (var alarm in alarms)
            {
                alarmsDto.Add(alarm.AssignToDto());
            }

            return Ok(alarmsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlarmDto>> GetAlarmByIdAsync(int id)
        {
            var alarm = await _alarmRepo.GetByIdAsync(id);

            if (alarm == null)
            {
                return NotFound();
            }

            return Ok(alarm.AssignToDto());
        }

        [HttpGet("{id}/dismiss")]
        public async Task<ActionResult<AlarmDto>> DismissActiveAlarmAsync(int id)
        {
            Alarm alarm = await _alarmRepo.GetByIdAsync(id);

            if (alarm == null)
            {
                return NotFound();
            }

            try
            {
                _alarmRepo.DismissAlarm(alarm);
                await _alarmRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Alarm>> CreateAlarmAsync([FromBody] AlarmDto alarmDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Alarm alarm = new Alarm();
                alarm.AssignFromDto(alarmDto);

                await _alarmRepo.AddAsync(alarm);
                await _alarmRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "A problem occurred when handling your request");
            }

            return StatusCode(201);
        }

    }
}