using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class AlarmsController : BaseController
    {
        private readonly IAlarmRepository _alarmRepo;
        private readonly ILogger<AlarmsController> _logger;

        public AlarmsController(ILogger<AlarmsController> logger, IAlarmRepository alarmRepo) : base(logger)
        {
            _alarmRepo = alarmRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Alarm>>> GetActiveAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetActiveAlarmsAsync();
            return Ok(alarms);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IList<Alarm>>> GetAllAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetAllAsync();
            return Ok(alarms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alarm>> GetAlarmByIdAsync(int id)
        {
            Alarm alarm = await _alarmRepo.GetByIdAsync(id);
            if (alarm == null)
            {
                return NotFound();
            }

            return Ok(alarm);
        }

        [HttpGet("type/{alarmType}")]
        public async Task<ActionResult<IList<Alarm>>> GetAlarmsByTypeAsync(string alarmType)
        {
            var alarms = await _alarmRepo.GetAlarmsByTypeAsync(alarmType);
            return Ok(alarms);
        }

        [HttpGet("{id}/dismiss")]
        public async Task<ActionResult<Alarm>> DismissActiveAlarmAsync(int id)
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
        public async Task<ActionResult<Alarm>> CreateAlarmAsync([FromBody] Alarm alarm)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _alarmRepo.CreateAsync(alarm);
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