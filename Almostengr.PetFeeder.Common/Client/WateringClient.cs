using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class WateringClient : BaseClient, IWateringClient
    {
        public WateringClient()
        {
        }

        public async Task<Uri> CreateWateringAsync(Watering watering)
        {
            return await CreateAsync<Watering>("/waterings", watering);
        }
        
        public async Task<IList<Watering>> GetAllWateringsAsync()
        {
            return await GetAsync<IList<Watering>>("/waterings/all");
        }

        public async Task<IList<Watering>> GetRecentWateringsAsync()
        {
            return await GetAsync<IList<Watering>>("/waterings");
        }

        public async Task<bool?> GetWaterBowlStatus()
        {
            return await GetAsyncBool("/waterings/status/bowllow");
        }

        public async Task<Watering> GetWateringAsync(int id)
        {
            return await GetAsync<Watering>($"/waterings/{id}");
        }

    }
}