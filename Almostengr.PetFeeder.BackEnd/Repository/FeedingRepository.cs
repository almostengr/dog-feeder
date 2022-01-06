using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public class FeedingRepository : IFeedingRepository
    {
        private readonly PetFeederContext _dbContext;

        public FeedingRepository(PetFeederContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FeedingDto> CreateFeedingAsync(Feeding feeding)
        {
            var result = await _dbContext.Feedings.AddAsync(feeding);
            await _dbContext.SaveChangesAsync();

            return result.Entity.ToFeedingDto();
        }

        public async Task<FeedingDto> GetFeedingAsync(int id)
        {
            return await _dbContext.Feedings
                .Where(f => f.FeedingId == id)
                .Select(f => f.ToFeedingDto())
                .SingleOrDefaultAsync();
        }

        public async Task<List<FeedingDto>> GetFeedingsAsync()
        {
            return await _dbContext.Feedings
                .OrderByDescending(f => f.Created)
                .Select(f => f.ToFeedingDto())
                .ToListAsync();
        }
    }
}