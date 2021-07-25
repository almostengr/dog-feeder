using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class SettingClient : BaseClient, ISettingClient
    {
        public SettingClient() : base() { }

        public Task<Setting> GetSettingAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Setting>> GetSettingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Setting> UpdateSettingAsync(Setting setting)
        {
            throw new System.NotImplementedException();
        }
    }
}