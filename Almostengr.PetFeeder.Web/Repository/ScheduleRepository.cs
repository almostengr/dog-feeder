using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Data;
using Almostengr.PetFeeder.Web.Enums;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Repository
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

        public Task<Schedule> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Schedule>> GetLatestAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Schedule>> GetOldOneTimeSchedulesAsync()
        {
            return await _dbContext.Schedules
                .Where(s => s.ScheduledTime <= DateTime.Now && 
                    s.Frequency == DayFrequency.Once)
                .ToListAsync();
        }
    }
}
