using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Models;
using Almostengr.DogFeeder.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.DogFeeder.Api.Data
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

        public async Task<Schedule> GetScheduleAsync(int id)
        {
            return await _dbContext.Schedules.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateSchedule(Schedule entity)
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
    }
}