using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class SettingClient : BaseClient, ISettingClient
    {
        public SettingClient() : base() { }

        public async Task<Setting> GetSettingAsync(string id)
        {
            return await GetAsync<Setting>($"/settings/{id}");
        }

        public async Task<IList<Setting>> GetSettingsAsync()
        {
            return await GetAsync<IList<Setting>>("/settings");
        }

        public async Task<Setting> UpdateSettingAsync(Setting setting)
        {
            return await UpdateAsync<Setting>("/settings", setting);
        }
    }
}