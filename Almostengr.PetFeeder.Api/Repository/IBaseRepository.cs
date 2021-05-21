using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        // T GetByIdAsync(int id);
        // IList<T> GetAllAsync();
        Task AddAsync(T entity);
        void Remove(T entity);
        void RemoveRange(IList<T> entities);
        void Update(T entity);
    }
}
