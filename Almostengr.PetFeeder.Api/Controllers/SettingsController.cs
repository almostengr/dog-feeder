using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingRepository _repository;

        public SettingsController(ILogger<SettingsController> logger, ISettingRepository repository) :
        base(logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Setting>>> GetAllSettingsAsync()
        {
            _logger.LogInformation("Getting all settings");

            IList<Setting> settings = await _repository.GetAllAsync();
            return Ok(settings);
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<Setting>> GetSettingByKeyAsync(string key)
        {
            Setting setting = await _repository.GetSettingByKeyAsync(key);

            if (setting == null)
            {
                return NotFound();
            }

            return Ok(setting);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> UpdateSettingAsync(string key, [FromBody] Setting setting)
        {
            Setting existingSetting = await _repository.GetSettingByKeyAsync(key);

            if (existingSetting == null)
            {
                return NotFound();
            }

            setting.Type = existingSetting.Type;

            _repository.Update(setting);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<IList<Setting>>> UpdateAllSettingsAsync([FromBody] IList<Setting> settings)
        {
            try
            {
                _repository.UpdateRange(settings);
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