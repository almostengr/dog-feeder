using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface IFeedingClient
    {
        Task<IList<FeedingDto>> GetAllFeedingsAsync();
        Task<FeedingDto> GetFeedingAsync(int id);
        Task<FeedingDto> CreateFeedingAsync(FeedingDto feedingDto);
        Task<IList<FeedingDto>> GetLatestFeedingsAsync();
    }
}