using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client
{
    public class SettingClient : BaseClient, ISettingClient
    {
        public SettingClient() : base() { }

        public async Task<SettingDto> GetSettingAsync(string id)
        {
            return await GetAsync<SettingDto>($"/settings/{id}");
        }

        public async Task<IList<SettingDto>> GetSettingsAsync()
        {
            return await GetAsync<IList<SettingDto>>("/settings");
        }

        public async Task<SettingDto> UpdateSettingAsync(SettingDto setting)
        {
            return await UpdateAsync<SettingDto>("/settings", setting);
        }
    }
}