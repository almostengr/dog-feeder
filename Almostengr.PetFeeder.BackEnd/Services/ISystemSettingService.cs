using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public interface ISystemSettingService
    {
        Task<SystemSettingDto> GetSystemSettingAsync(string name);
        Task<SystemSettingDto> UpdateSystemSettingAsync(SystemSettingDto systemSetting);
        Task<List<SystemSettingDto>> GetSystemSettingsAsync();
    }
}