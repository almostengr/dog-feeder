using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.Api.Repository
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private readonly DogFeederDbContext _dbContext;

        public ScheduleRepository(DogFeederDbContext dbContext) :
            base(dbContext)
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

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _dbContext.Schedules.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateSchedule(Schedule entity)
        {
            await _dbContext.Schedules.AddAsync(entity);
        }

        public async Task DeleteSchedule(int scheduleId)
        {
            if (scheduleId == null)
            {
                throw new ArgumentNullException(nameof(scheduleId));
            }

            Schedule schedule = await GetScheduleByIdAsync(scheduleId);

            _dbContext.Schedules.Remove(schedule);
        }

        public async Task SaveChangesAsync(){
            await _dbContext.SaveChangesAsync();
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
