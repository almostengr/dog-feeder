using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Models;
using Almostengr.DogFeeder.Models;

namespace Almostengr.DogFeeder.Api.Data
{
    public interface IFeedingRepository
    {
        Task CreateFeeding(Feeding entity);
        Task<List<Feeding>> GetAllFeedingsAsync();
        Task<Feeding> GetFeedingAsync(int id);
        Task SaveChangesAsync();
    }
}