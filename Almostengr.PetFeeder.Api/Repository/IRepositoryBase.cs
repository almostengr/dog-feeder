using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IRepositoryBase<Entity> where Entity : ModelBase
    {
        // public async Task Delete(int id)
        void Delete(Entity entity);
        Task<IList<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task CreateAsync(Entity entity);
        void Update(Entity entity);
        Task SaveChangesAsync();
    }
}