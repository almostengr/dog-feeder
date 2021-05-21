using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IFeedingRepository
    {
        Task CreateFeeding(Feeding entity);
        Task<List<Feeding>> GetAllFeedingsAsync();
        Task<Feeding> GetFeedingByIdAsync(int id);
        Task SaveChangesAsync();
        Task<List<Feeding>> GetRecentFeedingsAsync();
        Task<List<Feeding>> FindOldFeedings();
        Task DeleteFeeding(int id);
    }
}