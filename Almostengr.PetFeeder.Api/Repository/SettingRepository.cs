using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Repository
{
    public class SettingRepository : BaseRepository, ISettingRepository
    {
        private readonly PetFeederDbContext _dbContext;
        private readonly ILogger<SettingRepository> _logger;

        public SettingRepository(PetFeederDbContext dbContext, ILogger<SettingRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Setting>> GetAllSettingsAsync()
        {
            _logger.LogInformation("Getting all setings");
            return await _dbContext.Settings.ToListAsync();
        }

        public async Task<Setting> GetSettingByKeyAsync(string key)
        {
            _logger.LogInformation("Getting single setting");
            return await _dbContext.Settings.FirstOrDefaultAsync(s => s.Key == key);
        }

        public void UpdateSetting(Setting setting)
        {
            _logger.LogInformation("Updating setting " + setting.Key);
            _dbContext.Settings.Update(setting);
        }

    }
}