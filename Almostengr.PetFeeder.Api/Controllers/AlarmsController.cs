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
        private readonly IAlarmRepository _repository;

        public AlarmsController(ILogger<AlarmsController> logger, IAlarmRepository repository) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Alarm>>> GetActiveAlarmsAsync()
        {
            var alarms = await _repository.GetActiveAlarmsAsync();
            return Ok(alarms);
        }

        [HttpGet("dismiss")]
        public async Task<ActionResult<Alarm>> DismissActiveAlarmsAsync()
        {
            var alarms = await _repository.GetActiveAlarmsAsync();

            foreach (var alarm in alarms)
            {
                alarm.IsActive = false;
            }

            _repository.UpdateAlarms(alarms);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IList<Alarm>>> GetAllAlarmsAsync()
        {
            var alarms = await _repository.GetAllAlarmsAsync();
            return Ok(alarms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alarm>> GetAlarmByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var alarm = await _repository.GetAlarmByIdAsync(id);
            return Ok(alarm);
        }
    }
}