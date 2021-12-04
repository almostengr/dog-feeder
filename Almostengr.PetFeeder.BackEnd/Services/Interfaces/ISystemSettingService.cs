using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface ISystemSettingService
    {
        Task<List<SystemSettingDto>> GetAllSettingsAsync();
        Task<SystemSettingDto> UpdateSettingAsync(SystemSettingDto systemSetting);
        Task<SystemSettingDto> GetSettingByNameAsync(SettingName settingName);
    }
}