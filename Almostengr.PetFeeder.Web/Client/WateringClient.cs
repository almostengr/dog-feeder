using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client
{
    public class WateringClient : BaseClient, IWateringClient
    {
        public async Task<WateringDto> CreateWateringAsync(WateringDto wateringDto)
        {
            return await PostAsync<WateringDto>("/api/waterings", wateringDto);
        }
        
        public async Task<IList<WateringDto>> GetAllWateringsAsync()
        {
            return await GetAsync<IList<WateringDto>>("/api/waterings/all");
        }

        public async Task<IList<WateringDto>> GetLatestWateringsAsync()
        {
            return await GetAsync<IList<WateringDto>>("/api/waterings");
        }

        public async Task<bool?> GetWaterBowlStatus()
        {
            return await GetAsyncBool("/api/waterings/status/bowllow");
        }

        public async Task<WateringDto> GetWateringAsync(int id)
        {
            return await GetAsync<WateringDto>($"/api/waterings/{id}");
        }

    }
}