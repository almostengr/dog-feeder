using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Repository
{
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        private readonly PetFeederDbContext _dbContext;
        private readonly ILogger<SettingRepository> _logger;

        public SettingRepository(PetFeederDbContext dbContext, ILogger<SettingRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Setting> GetSettingByKeyAsync(string key)
        {
            _logger.LogInformation("Getting single setting");
            return await _dbContext.Settings.FirstOrDefaultAsync(s => s.Key == key);
        }

    }
}