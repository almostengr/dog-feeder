using Almostengr.PetFeeder.BackEnd.Repository;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly PetFeederContext _dbContext;

        protected BaseRepository(PetFeederContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}