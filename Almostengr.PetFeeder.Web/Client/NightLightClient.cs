using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace  Almostengr.PetFeeder.Web.Client
{
    public class NightLightClient : BaseClient, INightLightClient
    {
        public NightLightClient() : base() {}

        public async Task<NightLightDto> CreateNightLightAsync(NightLightDto nightLightDto)
        {
            return await PostAsync<NightLightDto>("/api/nightlights", nightLightDto);
        }

    }
}