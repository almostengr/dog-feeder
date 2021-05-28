using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Repository
{
    public class WateringRepository : RepositoryBase<Watering>, IWateringRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public WateringRepository(ILogger<WateringRepository> logger, PetFeederDbContext dbContext) :
            base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Watering>> GetRecentWateringsAsync()
        {
            DateTime currentDateTime = DateTime.Now;

            return await _dbContext.Waterings
                .Where(w => w.Timestamp >= currentDateTime.AddDays(-7))
                .OrderByDescending(w => w.Timestamp)
                .ToListAsync();
        }

    }
}