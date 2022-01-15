using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly PetFeederContext _dbContext;
        private readonly ILogger<ScheduleRepository> _logger;

        public ScheduleRepository(PetFeederContext dbContext, ILogger<ScheduleRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ScheduleDto> CreateScheduleAsync(Schedule schedule)
        {
            var createdSchedule = await _dbContext.Schedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync();
            return createdSchedule.Entity.ToScheduleDto();
        }

        public async Task<bool> DeleteScheduleAsync(Schedule schedule)
        {
            _dbContext.Schedules.Remove(schedule);
            await _dbContext.SaveChangesAsync();
            return true;
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