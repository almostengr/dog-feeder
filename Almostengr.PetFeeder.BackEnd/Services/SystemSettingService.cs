using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Repository;
using Almostengr.PetFeeder.BackEnd.Services;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class SystemSettingService : ISystemSettingService
    {
        private readonly ISystemSettingRepository _repository;
        private readonly ILogger<SystemSettingService> _logger;

        public SystemSettingService(ISystemSettingRepository repository, ILogger<SystemSettingService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<SystemSettingDto> CreateSystemSettingAsync(SystemSettingDto systemSettingDto)
        {
            if (systemSettingDto == null)
            {
                return null;
            }

            SystemSetting systemSetting = new SystemSetting(systemSettingDto);
            systemSetting.Created = DateTime.Now;
            systemSetting.Modified = systemSetting.Created;

            return await _repository.CreateSystemSettingAsync(systemSetting);
        }

        public async Task<bool> DeleteSystemSettingAsync(string settingName)
        {
            SystemSettingDto settingDto = await _repository.GetSystemSettingAsync(settingName);

            if (settingDto == null)
            {
                _logger.LogError($"Setting with name {settingName} does not exist");
                return false;
            }

            SystemSetting systemSetting = new SystemSetting(settingDto);
            return await _repository.DeleteSystemSettingAsync(systemSetting);
        }

        public async Task<SystemSettingDto> GetSystemSettingAsync(string name)
        {
            return await _repository.GetSystemSettingAsync(name);
        }

        public async Task<List<SystemSettingDto>> GetSystemSettingsAsync()
        {
            return await _repository.GetSystemSettingsAsync();
        }

        public async Task<SystemSettingDto> UpdateSystemSettingAsync(SystemSettingDto systemSettingDto)
        {
            SystemSetting setting = await _repository.GetSystemSettingEntity(systemSettingDto.Name);

            if (setting == null)
            {
                _logger.LogError($"System setting with name {systemSettingDto.Name} does not exist.");
                return null;
            }

            setting.Modified = DateTime.Now;
            setting.Value = systemSettingDto.Value;

            return await _repository.UpdateSystemSettingAsync(setting);
        }

    }
}
