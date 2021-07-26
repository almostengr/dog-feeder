using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface ISettingClient
    {
        Task<IList<SettingDto>> GetSettingsAsync();
        Task<SettingDto> GetSettingAsync(string id);
        Task<SettingDto> UpdateSettingAsync(SettingDto setting);
    }
}