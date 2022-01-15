using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public class SystemSettingController : BaseApiController
    {
        private readonly ISystemSettingService _service;

        public SystemSettingController(ILogger<BaseApiController> logger, ISystemSettingService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("{settingName}")]
        public async Task<IActionResult> GetSystemSetting(string settingName)
        {
            SystemSettingDto systemSettingDto = await _service.GetSystemSettingAsync(settingName);

            if (systemSettingDto == null)
            {
                return NotFound();
            }

            return Ok(systemSettingDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetSystemSettings()
        {
            List<SystemSettingDto> systemSettingDtos = await _service.GetSystemSettingsAsync();
            return Ok(systemSettingDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSystemSetting(SystemSettingDto systemSettingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            SystemSettingDto createdSystemSetting = await _service.CreateSystemSettingAsync(systemSettingDto);

            if (createdSystemSetting == null)
            {
                return StatusCode(500, "Failed to create system setting");
            }

            return CreatedAtAction(nameof(GetSystemSetting), new { settingName = createdSystemSetting.Name }, createdSystemSetting);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSystemSetting(SystemSettingDto systemSetting)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            SystemSettingDto updatedSystemSetting = await _service.UpdateSystemSettingAsync(systemSetting);

            if (updatedSystemSetting == null)
            {
                return StatusCode(500, "Failed to update system setting");
            }

            return Ok(updatedSystemSetting);
        }

        [HttpDelete("{settingName}")]
        public async Task<IActionResult> DeleteSystemSetting(string settingName)
        {
            bool isDeleted = await _service.DeleteSystemSettingAsync(settingName);

            if (isDeleted)
            {
                return StatusCode(500, "Failed to delete system setting");
            }
            
            return NoContent();
        }

    }
}