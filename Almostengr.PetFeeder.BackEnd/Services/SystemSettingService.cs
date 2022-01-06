using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class SystemSettingService : ISystemSettingService
    {
        private readonly ISystemSettingRepository _repository;

        public SystemSettingService(ISystemSettingRepository repository)
        {
            _repository = repository;
        }

        public async Task<SystemSettingDto> CreateSystemSettingAsync(SystemSettingDto systemSettingDto)
        {
            SystemSetting systemSetting = new SystemSetting(systemSettingDto);
            systemSettingDto.Created = DateTime.Now;
            systemSettingDto.Modified = DateTime.Now;

            return await _repository.CreateSystemSettingAsync(systemSetting);
        }

        public async Task DeleteSystemSettingAsync(string settingName)
        {
            var settingDto = await _repository.GetSystemSettingAsync(settingName);

            if (settingDto == null)
            {
                throw new ArgumentException($"Setting with name {settingName} does not exist");
            }

            SystemSetting systemSetting = new SystemSetting(settingDto);
            await _repository.DeleteSystemSettingAsync(systemSetting);
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
                throw new ArgumentException($"System setting with name {systemSettingDto.Name} does not exist.");
            }
            
            setting.Modified = DateTime.Now;
            setting.Value = systemSettingDto.Value;

            return await _repository.UpdateSystemSettingAsync(setting);
        }
    }
}