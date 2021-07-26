using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Almostengr.PetFeeder.Common.DataTransferObject;
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
        public async Task<ActionResult<IList<SettingDto>>> GetAllSettingsAsync()
        {
            IList<Setting> settings = await _settingRepository.GetAllAsync();
            var settingsDto = new List<SettingDto>();

            foreach (Setting setting in settings)
            {
                settingsDto.Add(setting.AssignToDto());
            }

            return Ok(settingsDto);
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<SettingDto>> GetSettingByKeyAsync(string key)
        {
            Setting setting = await _settingRepository.GetSettingByKeyAsync(key);

            if (setting == null)
            {
                return NotFound();
            }

            SettingDto settingDto = setting.AssignToDto();

            return Ok(settingDto);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> UpdateSettingAsync(string key, [FromBody] SettingDto settingDto)
        {
            Setting setting = await _settingRepository.GetSettingByKeyAsync(settingDto.Key);

            if (setting == null)
            {
                return NotFound();
            }

            try
            {
                setting.AssignFromDto(settingDto);

                _settingRepository.Update(setting);
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