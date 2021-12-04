using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface IFoodBowlRepository
    {
        Task<List<FeedingDto>> GetRecentFeedingsAsync();
        Task<List<FeedingDto>> GetAllFeedingsAsync();
        Task<FeedingDto> GetFeedingAsync(int id);
        Task<FeedingDto> AddFeedingAsync(FeedingDto feedingDto);
    }
}