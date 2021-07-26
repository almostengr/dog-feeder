using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IRepositoryBase<Entity> where Entity : ModelBase
    {
        void Delete(Entity entity);
        Task<IList<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task AddAsync(Entity entity);
        void Update(Entity entity);
        void UpdateRange(IList<Entity> entities);
        Task SaveChangesAsync();
    }
}