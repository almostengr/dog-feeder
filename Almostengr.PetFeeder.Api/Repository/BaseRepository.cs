using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly PetFeederDbContext _dbContext;
        private readonly ILogger<BaseRepository> _logger;

        public BaseRepository(PetFeederDbContext dbContext, ILogger<BaseRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        
    }
}