using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;

namespace Almostengr.PetFeeder.Web.Repository
{
    public interface IRepositoryBase<Entity> where Entity : ModelBase 
    {
        void Delete(Entity entity);
        Task<IList<Entity>> GetAllAsync();
        Task AddAsync(Entity entity);
        void Update(Entity entity);
        Task SaveChangesAsync();
    }
}