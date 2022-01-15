using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public class SystemSettingRepository : BaseRepository, ISystemSettingRepository
    {
        private readonly PetFeederContext _dbContext;
        private readonly ILogger<SystemSettingRepository> _logger;

        public SystemSettingRepository(PetFeederContext dbContext, ILogger<SystemSettingRepository> logger) : base(dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<SystemSettingDto> GetSystemSettingAsync(string name)
        {
            return await _dbContext.SystemSettings
                .Where(s => s.Name == name)
                .Select(s => s.ToSystemSettingDto())
                .SingleOrDefaultAsync();
        }

        public async Task<SystemSetting> GetSystemSettingEntity(string name)
        {
            return await _dbContext.SystemSettings
                .Where(s => s.Name == name)
                .SingleOrDefaultAsync();
        }

        public async Task<List<SystemSettingDto>> GetSystemSettingsAsync()
        {
            return await _dbContext.SystemSettings
                .OrderByDescending(s => s.Name)
                .Select(s => s.ToSystemSettingDto())
                .ToListAsync();
        }

        public async Task<SystemSettingDto> UpdateSystemSettingAsync(SystemSetting systemSetting)
        {
            var updatedEntity = _dbContext.SystemSettings.Update(systemSetting);
            await _dbContext.SaveChangesAsync();
            return updatedEntity.Entity.ToSystemSettingDto();
        }

    }
}