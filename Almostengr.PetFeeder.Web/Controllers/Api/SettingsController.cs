using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Repository;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Almostengr.PetFeeder.Web.Constants;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class SettingsController : BaseApiController
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingRepository _settingRepository;

        public SettingsController(ILogger<SettingsController> logger, ISettingRepository settingRepository) :
        base(logger)
        {
            _logger = logger;
            _settingRepository = settingRepository;
        }

        // GET /api/settings
        [HttpGet]
        public async Task<ActionResult<IList<SettingDto>>> GetAllSettingsAsync()
        {
            IList<Setting> settings = await _settingRepository.GetAllAsync();

            return Ok(settings.Select(s => s.AssignToDto()).ToList());
        }

        // GET /api/settings/{key}
        [HttpGet("{key}")]
        public async Task<ActionResult<SettingDto>> GetSettingByKeyAsync(string key)
        {
            Setting setting = await _settingRepository.GetSettingByKeyAsync(key);

            return Ok(setting.AssignToDto());
        }

        // PUT /api/settings
        [HttpPut]
        public async Task<ActionResult> UpdateSettingAsync([FromBody] SettingDto settingDto)
        {
            Setting setting = await _settingRepository.GetSettingByKeyAsync(settingDto.Key);

            if (setting == null)
            {
                return NotFound();
            }

            try
            {
                setting.CreateFromDto(settingDto);

                _settingRepository.Update(setting);
                await _settingRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ErrorMessage.Api500);
            }

            return NoContent();
        }

    }
}