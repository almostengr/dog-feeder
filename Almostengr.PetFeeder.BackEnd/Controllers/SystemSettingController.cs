using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
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

        [HttpGet("name")]
        public async Task<IActionResult> GetSystemSetting(string settingName)
        {
            var systemSetting = await _service.GetSystemSettingAsync(settingName);
            return Ok(systemSetting);
        }

        [HttpGet]
        public async Task<IActionResult> GetSystemSettings()
        {
            var systemSettings = await _service.GetSystemSettingsAsync();
            return Ok(systemSettings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSystemSetting(SystemSettingDto systemSettingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var createdSystemSetting = await _service.CreateSystemSettingAsync(systemSettingDto);
            return CreatedAtRoute(nameof(GetSystemSetting), new { settingName = createdSystemSetting.Name }, createdSystemSetting);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSystemSetting(SystemSettingDto systemSetting)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var updatedSystemSetting = await _service.UpdateSystemSettingAsync(systemSetting);
            return Ok(updatedSystemSetting);
        }

        [HttpDelete("{settingName}")]
        public async Task<IActionResult> DeleteSystemSetting(string settingName)
        {
            await _service.DeleteSystemSettingAsync(settingName);
            return NoContent();
        }
        
    }
}