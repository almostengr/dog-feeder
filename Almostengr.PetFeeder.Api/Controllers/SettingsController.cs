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
        private readonly ISettingRepository _settingRepository;

        public SettingsController(ILogger<SettingsController> logger, ISettingRepository settingRepository) :
        base(logger)
        {
            _logger = logger;
            _settingRepository = settingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Setting>>> GetAllSettingsAsync()
        {
            IList<Setting> settings = await _settingRepository.GetAllAsync();
            return Ok(settings);
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<Setting>> GetSettingByKeyAsync(string key)
        {
            Setting setting = await _settingRepository.GetSettingByKeyAsync(key);

            if (setting == null)
            {
                return NotFound();
            }

            return Ok(setting);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> UpdateSettingAsync(string key, [FromBody] Setting setting)
        {
            Setting existingSetting = await _settingRepository.GetSettingByKeyAsync(key);

            if (existingSetting == null)
            {
                return NotFound();
            }

            setting.Type = existingSetting.Type;

            _settingRepository.Update(setting);
            await _settingRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<IList<Setting>>> UpdateAllSettingsAsync([FromBody] IList<Setting> settings)
        {
            try
            {
                _settingRepository.UpdateRange(settings);
                await _settingRepository.SaveChangesAsync();
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