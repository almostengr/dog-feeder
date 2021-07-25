using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface ISettingClient
    {
        Task<IList<Setting>> GetSettingsAsync();
        Task<Setting> GetSettingAsync(string id);
        Task<Setting> UpdateSettingAsync(Setting setting);
    }
}