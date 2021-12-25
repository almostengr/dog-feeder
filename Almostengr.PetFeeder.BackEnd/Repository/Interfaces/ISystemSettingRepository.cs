using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface ISystemSettingRepository
    {
        Task<SystemSettingDto> GetSystemSettingAsync(string name);
        Task<SystemSettingDto> UpdateSystemSettingAsync(SystemSettingDto systemSetting);
        Task<SystemSettingDto> CreateSystemSettingAsync(SystemSettingDto systemSetting);
        Task SaveChangesAsync();
    }
}