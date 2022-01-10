using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
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

        public async Task<SystemSettingDto> CreateSystemSettingAsync(SystemSetting systemSetting)
        {
            try
            {
                var result = await _dbContext.SystemSettings.AddAsync(systemSetting);
                await _dbContext.SaveChangesAsync();
                return result.Entity.ToSystemSettingDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteSystemSettingAsync(SystemSetting systemSetting)
        {
            try
            {
                _dbContext.SystemSettings.Remove(systemSetting);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<SystemSettingDto> GetSystemSettingAsync(string name)
        {
            return await _dbContext.SystemSettings
                .Where(s => s.Name == name)
                .Select(s => s.ToSystemSettingDto())
                .SingleOrDefaultAsync();
        }

        public Task<SystemSetting> GetSystemSettingEntity(string name)
        {
            throw new NotImplementedException();
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
            try
            {
                var updatedEntity = _dbContext.SystemSettings.Update(systemSetting);
                await _dbContext.SaveChangesAsync();
                return updatedEntity.Entity.ToSystemSettingDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

    }
}