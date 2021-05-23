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
    public class WateringRepository : BaseRepository, IWateringRepository
    {
        // private readonly ILogger<WateringRepository> _logger;
        private readonly PetFeederDbContext _dbContext;

        public WateringRepository(ILogger<WateringRepository> logger, PetFeederDbContext dbContext) :
            base(dbContext, logger)
        {
            // _logger = logger;
            _dbContext = dbContext;
        }

        public async Task CreateWateringAsync(Watering watering)
        {
            await _dbContext.Waterings.AddAsync(watering);
        }

        public async Task<List<Watering>> GetAllWateringsAsync()
        {
            return await _dbContext.Waterings
                .OrderByDescending(w => w.Timestamp)
                .ToListAsync();
        }

        public async Task<Watering> GetWateringByIdAsync(int? wateringId)
        {
            return await _dbContext.Waterings
                .Where(w => w.Id == wateringId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Watering>> GetRecentWateringsAsync()
        {
            DateTime currentDateTime = DateTime.Now;

            return await _dbContext.Waterings
                .Where(w => w.Timestamp >= currentDateTime.AddDays(-7))
                .OrderByDescending(w => w.Timestamp)
                .ToListAsync();
        }

        public void UpdateWatering(Watering watering)
        {
            _dbContext.Waterings.Update(watering);
        }
    }
}