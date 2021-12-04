using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface IFoodBowlService
    {
        Task<FeedingDto> GetFeedingAsync(int id);
        Task<List<FeedingDto>> GetRecentFeedingsAsync();
        Task<List<FeedingDto>> GetFeedingsAsync();
        Task<FeedingDto> PerformFeedingAsync(FeedingDto FeedingDto);
        // Task<FeedingDto> UpdateFeedingAsync(FeedingDto FeedingDto);
        // Task<FeedingDto> DeleteFeedingAsync(int id);
    }
}