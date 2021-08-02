using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Data;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Repository
{
    public class FeedingRepository : RepositoryBase<Feeding>, IFeedingRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public FeedingRepository(PetFeederDbContext dbContext, ILogger<FeedingRepository> logger) :
            base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Feeding>> GetLatestAsync()
        {
            return await _dbContext.Feedings
                .OrderByDescending(f => f.Created)
                .Take(5)
                .ToListAsync();
        }

        public async Task<Feeding> GetByIdAsync(int id)
        {
            return await _dbContext.Feedings
                .Where(f => f.FeedingId == id)
                .SingleOrDefaultAsync();
        }

    }
}