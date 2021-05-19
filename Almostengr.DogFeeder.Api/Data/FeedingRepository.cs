using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Models;
using Almostengr.DogFeeder.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.DogFeeder.Api.Data
{
    public class FeedingRepository : BaseRepository, IFeedingRepository
    {
        private readonly DogFeederDbContext _dbContext;

        public FeedingRepository(DogFeederDbContext dbContext) :
            base(dbContext)
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
                .Where(f => f.Timestamp >= currentDate.AddDays(-7))
                .OrderByDescending(f => f.Timestamp)
                .ToListAsync();
        }

        public async Task<Feeding> GetFeedingAsync(int id)
        {
            return await _dbContext.Feedings.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task CreateFeeding(Feeding entity)
        {
            await _dbContext.Feedings.AddAsync(entity);
        }

        public async Task SaveChangesAsync(){
            await _dbContext.SaveChangesAsync();
        }
    }
}