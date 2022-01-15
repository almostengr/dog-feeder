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

        [HttpPut]
        public async Task<IActionResult> UpdateSystemSetting(SystemSettingDto systemSetting)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            SystemSettingDto updatedSystemSetting = await _service.UpdateSystemSettingAsync(systemSetting);

            return Ok(updatedSystemSetting);
        }

    }
}