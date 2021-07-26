using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace  Almostengr.PetFeeder.Common.Client
{
    public class NightLightClient : BaseClient, INightLightClient
    {
        public NightLightClient() : base() {}

        public async Task<Uri> CreateNightLightAsync(NightLightDto nightLight)
        {
            return await CreateAsync<NightLightDto>("/nightlights", nightLight);
        }

    }
}