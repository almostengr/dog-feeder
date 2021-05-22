using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface ISettingRepository : IBaseRepository
    {
        Task<List<Setting>> GetAllSettingsAsync();
        Task<Setting> GetSettingByKeyAsync(string key);
        void UpdateSetting(Setting setting);
    }
}