using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Repository
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
            _dbContext.Alarms.Update(alarm);
        }

        public async Task<bool> GetActiveAlarmsExistByTypeAsync(string type)
        {
            return await _dbContext.Alarms
                .Where(a => a.Type == type && a.IsActive == true)
                .AnyAsync();
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
    }
}