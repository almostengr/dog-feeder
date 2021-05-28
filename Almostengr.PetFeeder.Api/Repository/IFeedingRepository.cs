using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IFeedingRepository : IRepositoryBase<Feeding>
    {
        // Task CreateFeedingAsync(Feeding feeding);
        // Task<List<Feeding>> GetAllFeedingsAsync();
        // Task<Feeding> GetFeedingByIdAsync(int? id);
        Task<List<Feeding>> GetRecentFeedingsAsync();
        // Task<List<Feeding>> FindOldFeedings();
    }
}