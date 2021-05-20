using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.Api.Data
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
                .OrderByDescending(f => f.Timestamp)
                .Take(10)
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