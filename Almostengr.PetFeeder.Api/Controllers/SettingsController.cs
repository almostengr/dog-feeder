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

            IList<Setting> settings = await _repository.GetAllSettingsAsync();
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
        public async Task<ActionResult> UpdateSettingAsync(string key, Setting setting)
        {
            Setting existingSetting = await _repository.GetSettingByKeyAsync(key);

            if (existingSetting == null)
            {
                return NotFound();
            }

            setting.Type = existingSetting.Type;

            _repository.UpdateSetting(setting);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

    }
}