using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Models;

namespace Almostengr.DogFeeder.Api.Data
{
    public interface IFeedingRepository
    {
        Task Create(Feeding entity);
        Task<List<Feeding>> GetAllFeedingsAsync();
        Task<Feeding> GetFeedingAsync(int id);
        Task SaveChangesAsync();
    }
}