using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly PetFeederContext _dbContext;

        public ScheduleRepository(PetFeederContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ScheduleDto> CreateScheduleAsync(Schedule schedule)
        {
            var createdSchedule = await _dbContext.Schedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync();

            return createdSchedule.Entity.ToScheduleDto();
        }

        public async Task DeleteScheduleAsync(Schedule schedule)
        {
            _dbContext.Schedules.Remove(schedule);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ScheduleDto> GetScheduleAsync(int id)
        {
            return await _dbContext.Schedules
                .Where(s => s.ScheduleId == id)
                .Select(s => s.ToScheduleDto())
                .SingleOrDefaultAsync();
        }

        public async Task<Schedule> GetScheduleEntity(int scheduleId)
        {
            return await _dbContext.Schedules
                .Where(s => s.ScheduleId == scheduleId)
                .SingleOrDefaultAsync();
        }

        public async Task<List<ScheduleDto>> GetSchedulesAsync()
        {
            return await _dbContext.Schedules
                .OrderBy(s => s.ScheduleId)
                .Select(s => s.ToScheduleDto())
                .ToListAsync();
        }

        public async Task<List<ScheduleDto>> GetSchedulesByTimeAsync(TimeSpan time)
        {
            return await _dbContext.Schedules
                .Where(s => s.ScheduledTime.Hour == time.Hours && s.ScheduledTime.Minute == time.Minutes)
                .Select(s => s.ToScheduleDto())
                .ToListAsync();
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(Schedule schedule)
        {
            var updatedEntity = _dbContext.Schedules.Update(schedule);
            await _dbContext.SaveChangesAsync();

            return updatedEntity.Entity.ToScheduleDto();
        }
    }
}