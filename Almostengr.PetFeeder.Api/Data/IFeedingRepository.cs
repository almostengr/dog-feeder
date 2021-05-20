using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Models;

namespace Almostengr.PetFeeder.Api.Data
{
    public interface IFeedingRepository
    {
        Task CreateFeeding(Feeding entity);
        Task<List<Feeding>> GetAllFeedingsAsync();
        Task<Feeding> GetFeedingAsync(int id);
        Task SaveChangesAsync();
        Task<List<Feeding>> GetRecentFeedingsAsync();
    }
}