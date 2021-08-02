using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client
{
    public class SettingClient : BaseClient, ISettingClient
    {
        public SettingClient() : base() { }

        public async Task<SettingDto> GetSettingAsync(string id)
        {
            return await GetAsync<SettingDto>($"/api/settings/{id}");
        }

        public async Task<IList<SettingDto>> GetSettingsAsync()
        {
            return await GetAsync<IList<SettingDto>>("/api/settings");
        }

        public async Task<SettingDto> UpdateSettingAsync(SettingDto settingDto)
        {
            return await PutAsync<SettingDto>("/api/settings", settingDto);
        }
    }
}