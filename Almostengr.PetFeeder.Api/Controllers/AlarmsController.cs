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

        public AlarmsController(ILogger<AlarmsController> logger, IAlarmRepository alarmRepo) : base(logger)
        {
            _alarmRepo = alarmRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Alarm>>> GetActiveAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetActiveAlarmsAsync();
            return Ok(alarms);
        }

        [HttpGet("dismiss")]
        public async Task<ActionResult<Alarm>> DismissActiveAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetActiveAlarmsAsync();

            foreach (var alarm in alarms)
            {
                alarm.IsActive = false;
            }

            _alarmRepo.UpdateAlarms(alarms);
            await _alarmRepo.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IList<Alarm>>> GetAllAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetAllAlarmsAsync();
            return Ok(alarms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alarm>> GetAlarmByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var alarm = await _alarmRepo.GetAlarmByIdAsync(id);
            return Ok(alarm);
        }

        [HttpPost]
        public async Task<ActionResult<Alarm>> CreateAlarmAsync(Alarm alarm)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            alarm.Created = DateTime.Now;

            await _alarmRepo.CreateAlarmAsync(alarm);
            await _alarmRepo.SaveChangesAsync();

            // return Ok(alarm);
            return StatusCode(201);
        }

    }
}