using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface IFeedingService
    {
        Task<FeedingDto> GetFeedingAsync(int id);
        Task<List<FeedingDto>> GetFeedingsAsync();
        // Task<FeedingDto> CreateFeedingAsync(FeedingDto FeedingDto);
        Task CreateFeedingAsync(FeedingDto FeedingDto);
    }
}