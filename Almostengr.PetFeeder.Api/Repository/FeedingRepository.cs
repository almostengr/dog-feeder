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
    public class FeedingRepository : BaseRepository, IFeedingRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public FeedingRepository(PetFeederDbContext dbContext, ILogger<FeedingRepository> logger) :
            base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Feeding>> GetAllFeedingsAsync()
        {
            return await _dbContext.Feedings
                .OrderByDescending(f => f.Timestamp)
                .ToListAsync();
        }

        public async Task<List<Feeding>> GetRecentFeedingsAsync()
        {
            DateTime currentDate = DateTime.Now;

            return await _dbContext.Feedings
                .Where(f => f.Timestamp == DateTime.Now.AddDays(-7))
                .OrderByDescending(f => f.Timestamp)
                .ToListAsync();
        }

        public async Task<Feeding> GetFeedingByIdAsync(int? id)
        {
            return await _dbContext.Feedings.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task CreateFeedingAsync(Feeding entity)
        {
            await _dbContext.Feedings.AddAsync(entity);
        }

        public async Task<List<Feeding>> FindOldFeedings()
        {
            DateTime currentDateTime = DateTime.Now;
            return await _dbContext.Feedings
                .Where(f => f.Timestamp <= currentDateTime.AddDays(-90))
                .ToListAsync();
        }

        public void DeleteFeeding(Feeding feeding)
        {
            if (feeding == null)
            {
                throw new ArgumentNullException(nameof(feeding));
            }

            _dbContext.Feedings.Remove(feeding);
        }

        public void DeleteFeedings(List<Feeding> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _dbContext.Feedings.RemoveRange(entities);
        }

    }
}