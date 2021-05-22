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
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public ScheduleRepository(PetFeederDbContext dbContext, ILogger<ScheduleRepository> logger) :
            base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Schedule>> GetAllSchedulesAsync()
        {
            return await _dbContext.Schedules.ToListAsync();
        }

        public async Task<List<Schedule>> GetAllActiveSchedulesAsync()
        {
            return await _dbContext.Schedules.Where(s => s.IsActive == true).ToListAsync();
        }

        public async Task<Schedule> GetScheduleByIdAsync(int? scheduleId)
        {
            if (scheduleId == null)
            {
                throw new ArgumentNullException(nameof(scheduleId));
            }

            return await _dbContext.Schedules.FirstOrDefaultAsync(s => s.Id == scheduleId);
        }

        public async Task CreateScheduleAsync(Schedule entity)
        {
            await _dbContext.Schedules.AddAsync(entity);
        }

        public void DeleteSchedule(Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            _dbContext.Schedules.Remove(schedule);
        }

        public async Task<List<Schedule>> GetAllInactiveSchedulesAsync()
        {
            return await _dbContext.Schedules.Where(s => s.IsActive == false).ToListAsync();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _dbContext.Schedules.Update(schedule);
        }

        public async Task<List<Schedule>> GetOldOneTimeSchedulesAsync()
        {
            return await _dbContext.Schedules
                .Where(s => s.ScheduledTime <= DateTime.Now && s.Frequency == Enums.DayFrequency.Once)
                .ToListAsync();
        }
    }
}
