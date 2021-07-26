using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client
{
    public class WateringClient : BaseClient, IWateringClient
    {
        public WateringClient()
        {
        }

        public async Task<Uri> CreateWateringAsync(WateringDto watering)
        {
            return await CreateAsync<WateringDto>("/waterings", watering);
        }
        
        public async Task<IList<WateringDto>> GetAllWateringsAsync()
        {
            return await GetAsync<IList<WateringDto>>("/waterings/all");
        }

        public async Task<IList<WateringDto>> GetRecentWateringsAsync()
        {
            return await GetAsync<IList<WateringDto>>("/waterings");
        }

        public async Task<bool?> GetWaterBowlStatus()
        {
            return await GetAsyncBool("/waterings/status/bowllow");
        }

        public async Task<WateringDto> GetWateringAsync(int id)
        {
            return await GetAsync<WateringDto>($"/waterings/{id}");
        }

    }
}