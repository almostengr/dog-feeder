using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client
{
    public class FeedingClient : BaseClient, IFeedingClient
    {
        public FeedingClient() : base() {}

        public async Task<IList<FeedingDto>> GetAllFeedingsAsync()
        {
            return await GetAsync<IList<FeedingDto>>("/feedings");
        }

        public async Task<FeedingDto> GetFeedingAsync(int id)
        {
            return await GetAsync<FeedingDto>($"/feedings/{id}");
        }

        public async Task<Uri> CreateFeedingAsync(FeedingDto feeding)
        {
            return await CreateAsync<FeedingDto>("/feedings", feeding);
        }

    }
}