using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface ISystemSettingRepository
    {
        Task<List<SystemSettingDto>> GetSystemSettings();
        Task<SystemSettingDto> GetSystemSetting(SettingName name);
        Task<SystemSettingDto> UpdateSystemSetting(SystemSettingDto SystemSettingDto);
    }
    
}