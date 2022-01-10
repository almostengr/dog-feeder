using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public class FeedingRepository : IFeedingRepository
    {
        private readonly PetFeederContext _dbContext;
        private readonly ILogger<FeedingRepository> _logger;
        private readonly IFeedingRelay _relay;

        public FeedingRepository(PetFeederContext dbContext, ILogger<FeedingRepository> logger, IFeedingRelay relay)
        {
            _dbContext = dbContext;
            _logger = logger;
            _relay = relay;
        }

        public async Task<FeedingDto> CreateFeedingAsync(Feeding feeding)
        {
            try
            {
                var dispenseFood = await _relay.FeedMeAsync(feeding.Amount);
                if (dispenseFood == false)
                {
                    return null;
                }

                var createdFeeding = await _dbContext.Feedings.AddAsync(feeding);
                await _dbContext.SaveChangesAsync();

                return createdFeeding.Entity.ToFeedingDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
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