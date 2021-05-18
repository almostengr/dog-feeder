using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Schedule> GetScheduleAsync(int id)
        {
            return await _dbContext.Schedules.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Create(Schedule entity)
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

        private async Task<bool> ScheduleExists(int id)
        {
            return await _dbContext.Schedules.AnyAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync(){
            await _dbContext.SaveChangesAsync();
        }
    }
}