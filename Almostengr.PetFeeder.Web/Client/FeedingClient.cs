using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client
{
    public class FeedingClient : BaseClient, IFeedingClient
    {
        public FeedingClient() : base() {}

        public async Task<IList<FeedingDto>> GetAllFeedingsAsync()
        {
            return await GetAsync<IList<FeedingDto>>("/api/feedings");
        }

        public async Task<FeedingDto> GetFeedingAsync(int id)
        {
            return await GetAsync<FeedingDto>($"/api/feedings/{id}");
        }

        public async Task<FeedingDto> CreateFeedingAsync(FeedingDto feedingDto)
        {
            return await PostAsync<FeedingDto>("/api/feedings", feedingDto);
        }

        public async Task<IList<FeedingDto>> GetLatestFeedingsAsync()
        {
            return await GetAsync<IList<FeedingDto>>("/api/feedings");
        }
    }
}
