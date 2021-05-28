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
    public class FeedingRepository : RepositoryBase<Feeding>, IFeedingRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public FeedingRepository(PetFeederDbContext dbContext, ILogger<FeedingRepository> logger) :
            base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        // public async Task<List<Feeding>> GetAllFeedingsAsync()
        // {
        //     return await _dbContext.Feedings
        //         .OrderByDescending(f => f.Timestamp)
        //         .ToListAsync();
        // }

        public async Task<List<Feeding>> GetRecentFeedingsAsync()
        {
            DateTime currentDate = DateTime.Now;

            return await _dbContext.Feedings
                .OrderByDescending(f => f.Timestamp)
                .Take(5)
                .ToListAsync();
        }

        // public async Task<Feeding> GetFeedingByIdAsync(int? id)
        // {
        //     return await _dbContext.Feedings.FirstOrDefaultAsync(f => f.Id == id);
        // }

        // public async Task CreateFeedingAsync(Feeding feeding)
        // {
        //     await _dbContext.Feedings.AddAsync(feeding);
        // }

        // public async Task<List<Feeding>> FindOldFeedings()
        // {
        //     DateTime currentDateTime = DateTime.Now;
        //     return await _dbContext.Feedings
        //         .Where(f => f.Timestamp <= currentDateTime.AddDays(-90))
        //         .ToListAsync();
        // }

    }
}