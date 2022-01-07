using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public class SystemSettingRepository : BaseRepository, ISystemSettingRepository
    {
        private readonly PetFeederContext _dbContext;

        public SystemSettingRepository(PetFeederContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SystemSettingDto> CreateSystemSettingAsync(SystemSetting systemSetting)
        {
            List<SystemSettings> result = await _dbContext.SystemSettings.AddAsync(systemSetting);
            await _dbContext.SaveChangesAsync();

            return result.Entity.ToSystemSettingDto();
        }

        public async Task DeleteSystemSettingAsync(SystemSetting systemSetting)
        {
            _dbContext.SystemSettings.Remove(systemSetting);
            await _dbContext.SaveChangesAsync();
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
            SystemSettings updatedEntity = _dbContext.SystemSettings.Update(systemSetting);
            await _dbContext.SaveChangesAsync();

            return updatedEntity.Entity.ToSystemSettingDto();
        }

    }
}