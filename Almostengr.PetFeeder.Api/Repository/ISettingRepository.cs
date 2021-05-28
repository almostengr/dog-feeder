using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
        // Task<List<Setting>> GetAllSettingsAsync();
        Task<Setting> GetSettingByKeyAsync(string key);
        // void UpdateSetting(Setting setting);
    }
}