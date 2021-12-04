using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemSettingController : BaseApiController
    {
        private readonly ISystemSettingService _service;

        public SystemSettingController(ILogger<SystemSettingController> logger,
            ISystemSettingService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            IList<SystemSettingDto> getResponse = await _service.GetAllSettingsAsync();
            return Ok(getResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByKey(SettingName settingName)
        {
            SystemSettingDto getResponse = await _service.GetSettingByNameAsync(settingName);
            
            if (getResponse == null)
            {
                return NotFound();
            }

            return Ok(getResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SystemSettingDto systemSetting)
        {
            SystemSettingDto getResponse = await _service.GetSettingByNameAsync(systemSetting.SettingName);
            
            if (getResponse == null)
            {
                return NotFound();
            }
            
            SystemSettingDto updateResponse = await _service.UpdateSettingAsync(systemSetting);
            return Ok(updateResponse);
        }
    }
}