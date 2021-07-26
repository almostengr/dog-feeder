using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Repository
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public ScheduleRepository(PetFeederDbContext dbContext, ILogger<ScheduleRepository> logger) :
            base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Schedule>> GetAllActiveSchedulesAsync()
        {
            return await _dbContext.Schedules.Where(s => s.IsActive == true).ToListAsync();
        }

        public async Task<List<Schedule>> GetAllInactiveSchedulesAsync()
        {
            return await _dbContext.Schedules.Where(s => s.IsActive == false).ToListAsync();
        }

        public async Task<List<Schedule>> GetOldOneTimeSchedulesAsync()
        {
            return await _dbContext.Schedules
                .Where(s => s.ScheduledTime <= DateTime.Now && 
                    s.Frequency == Common.Enums.DayFrequency.Once)
                .ToListAsync();
        }
    }
}
