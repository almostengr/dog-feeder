using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.Api.Repository
{
    public class AlarmRepository : IAlarmRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public AlarmRepository(PetFeederDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAlarmAsync(Alarm alarm)
        {
            await _dbContext.Alarms.AddAsync(alarm);
        }

        public void UpdateAlarm(Alarm alarm)
        {
            _dbContext.Alarms.Update(alarm);
        }

        public void UpdateAlarms(List<Alarm> alarms)
        {
            _dbContext.Alarms.UpdateRange(alarms);
        }

        public async Task<bool> GetActiveAlarmsExistByTypeAsync(string type)
        {
            var result = await _dbContext.Alarms
                .Where(a => a.Type == type && a.IsActive == true)
                .ToListAsync();

            if (result.Count > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Alarm>> GetActiveAlarmsAsync()
        {
            return await _dbContext.Alarms.Where(a => a.IsActive == true).OrderByDescending(a => a.Created).ToListAsync();
        }

        public async Task<Alarm> GetAlarmByIdAsync(int id)
        {
            return await _dbContext.Alarms.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Alarm>> GetAllAlarmsAsync()
        {
            return await _dbContext.Alarms.OrderByDescending(a => a.Created).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}