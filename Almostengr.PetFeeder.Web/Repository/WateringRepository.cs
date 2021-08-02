using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Data;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Repository
{

    public class WateringRepository : RepositoryBase<Watering>, IWateringRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public WateringRepository(ILogger<WateringRepository> logger, PetFeederDbContext dbContext) :
            base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public async Task<Watering> GetByIdAsync(int id)
        {
            return await _dbContext.Waterings
                .Where(w => w.WateringId == id)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Watering>> GetLatestWateringsAsync()
        {
            return await _dbContext.Waterings
                .OrderByDescending(w => w.Created)
                .Take(5)
                .ToListAsync();
        }

    }
}