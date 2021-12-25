using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface IFeedingRepository
    {
        Task<List<FeedingDto>> GetFeedingsAsync();
        Task<FeedingDto> GetFeedingAsync(int id);
        Task<FeedingDto> CreateFeedingAsync(FeedingDto feedingDto);
        Task<FeedingDto> UpdateFeedingAsync(FeedingDto feedingDto);
        Task DeleteFeedingAsync(int id);
        Task SaveChangesAsync();
    }
}