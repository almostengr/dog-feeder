using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Data;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Repository
{
    

    public class AlarmRepository : RepositoryBase<Alarm>, IAlarmRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public AlarmRepository(PetFeederDbContext dbContext, ILogger<RepositoryBase<Alarm>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public void DismissAlarm(Alarm alarm)
        {
            alarm.IsActive = false;
            alarm.Modified = DateTime.Now;
            _dbContext.Alarms.Update(alarm);
        }

        public async Task<List<Alarm>> GetActiveAlarmsAsync()
        {
            return await _dbContext.Alarms
                .Where(a => a.IsActive == true)
                .OrderByDescending(a => a.Created)
                .ToListAsync();
        }

        public async Task<List<Alarm>> GetAlarmsByTypeAsync(string alarmType)
        {
            return await _dbContext.Alarms
                .Where(a => a.Type == alarmType && a.IsActive == true)
                .OrderByDescending(a => a.Created)
                .ToListAsync();
        }

        public async Task<Alarm> GetByIdAsync(int id)
        {
            return await _dbContext.Alarms
                .Where(a => a.AlarmId == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<Alarm>> GetLatestAsync()
        {
            return await _dbContext.Alarms
                .Where(a => a.IsActive == true)
                .OrderByDescending(a => a.Created)
                .Take(5)
                .ToListAsync();
        }

    }
}