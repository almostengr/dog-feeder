using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using System.Linq;
using Almostengr.PetFeeder.Web.Constants;

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

        // GET /api/alarms
        [HttpGet]
        public async Task<ActionResult<IList<AlarmDto>>> GetActiveAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetActiveAlarmsAsync();

            return Ok(alarms.Select(a => a.AssignToDto()).ToList());
        }

        // GET /api/alarms/all
        [HttpGet("all")]
        public async Task<ActionResult<IList<AlarmDto>>> GetAllAlarmsAsync()
        {
            var alarms = await _alarmRepo.GetAllAsync();

            return Ok(alarms.Select(a => a.AssignToDto()).ToList());
        }

        // GET /api/alarms/{id}
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

        // PUT /api/alarms
        [HttpPut]
        public async Task<ActionResult> UpdateAlarmAsync([FromBody] AlarmDto alarmDto)
        {
            Alarm alarm = await _alarmRepo.GetByIdAsync(alarmDto.AlarmId);

            if (alarm == null)
            {
                return NotFound();
            }

            try
            {
                alarm.UpdateFromDto(alarmDto);
                _alarmRepo.Update(alarm);
                await _alarmRepo.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

        // POST /api/alarms
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
                alarm.CreateFromDto(alarmDto);

                await _alarmRepo.AddAsync(alarm);
                await _alarmRepo.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAlarmByIdAsync), new { id = alarm.AlarmId }, alarm.AssignToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }
        }

    }
}