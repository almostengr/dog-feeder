using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Data;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public class MockScheduleRepository : IScheduleRepository
    {
        private readonly PetFeederContext _context;

        public MockScheduleRepository(PetFeederContext context)
        {
            _context = context;
        }

        public async Task<ScheduleDto> AddSchedule(ScheduleDto schedule)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ScheduleDto> GetSchedule(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ScheduleDto>> GetSchedules()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ScheduleDto>> GetSchedulesForCurrentTimeAsync()
        {
            DateTime currentDateTime = DateTime.Now;
            
            return await _context.Schedules
                .Where(s => s.ScheduledTime.Hour == currentDateTime.Hour &&  s.ScheduledTime.Minute == currentDateTime.Minute)
                .Select(ScheduleDto.ToDto())
                .ToListAsync();
        }

        public async Task<ScheduleDto> UpdateSchedule(ScheduleDto schedule)
        {
            throw new System.NotImplementedException();
        }
    }
}