using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface IFeedingRepository
    {
        Task<FeedingDto> CreateFeedingAsync(Feeding feeding);
        Task<FeedingDto> GetFeedingAsync(int id);
        Task<List<FeedingDto>> GetFeedingsAsync();
    }
}