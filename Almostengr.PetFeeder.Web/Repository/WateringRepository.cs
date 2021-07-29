using System;
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

        public Task<Watering> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Watering>> GetLatestAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Watering>> GetRecentWateringsAsync()
        {
            DateTime currentDateTime = DateTime.Now;

            return await _dbContext.Waterings
                .Where(w => w.Created >= currentDateTime.AddDays(-7))
                .OrderByDescending(w => w.Created)
                .ToListAsync();
        }

    }
}