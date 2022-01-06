using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface ISystemSettingRepository : IBaseRepository
    {
        Task<SystemSettingDto> GetSystemSettingAsync(string name);
        Task<List<SystemSettingDto>> GetSystemSettingsAsync();
        Task<SystemSetting> GetSystemSettingEntity(string name);
        Task<SystemSettingDto> CreateSystemSettingAsync(SystemSetting systemSetting);
        Task<SystemSettingDto> UpdateSystemSettingAsync(SystemSetting systemSetting);
        Task DeleteSystemSettingAsync(SystemSetting systemSetting);
    }
}