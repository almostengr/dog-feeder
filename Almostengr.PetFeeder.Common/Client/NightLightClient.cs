using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace  Almostengr.PetFeeder.Common.Client
{
    public class NightLightClient : BaseClient, INightLightClient
    {
        public NightLightClient() : base() {}

        public async Task<NightLight> CreateNightLightAsync(NightLight nightLight)
        {
            return await CreateAsync<NightLight>("/nightlights", nightLight);
        }

    }
}