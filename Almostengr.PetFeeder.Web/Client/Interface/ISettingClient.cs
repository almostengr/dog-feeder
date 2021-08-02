using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface ISettingClient
    {
        Task<IList<SettingDto>> GetSettingsAsync();
        Task<SettingDto> GetSettingAsync(string id);
        Task<SettingDto> UpdateSettingAsync(SettingDto settingDto);
    }
}