using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class FeedingClient : BaseClient, IFeedingClient
    {
        public FeedingClient() : base() {}

        public async Task<IList<Feeding>> GetAllFeedingsAsync()
        {
            return await GetAsync<IList<Feeding>>("/feedings");
        }

        public async Task<Feeding> GetFeedingAsync(int id)
        {
            return await GetAsync<Feeding>($"/feedings/{id}");
        }

        public async Task<Uri> CreateFeedingAsync(Feeding feeding)
        {
            return await CreateAsync<Feeding>("/feedings", feeding);
        }

    }
}