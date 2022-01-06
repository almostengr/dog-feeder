using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly PetFeederContext _dbContext;

        protected BaseRepository(PetFeederContext dbContext)
        {
            _dbContext = dbContext;
        }

        // public async Task<int> SaveChangesAsync()
        public async Task<bool> SaveChangesAsync()
        {
            // return await _dbContext.SaveChangesAsync();
            return (await _dbContext.SaveChangesAsync() >= 0);
        }
    }
}