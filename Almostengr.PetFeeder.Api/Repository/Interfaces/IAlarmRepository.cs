using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IAlarmRepository : IRepositoryBase<Alarm>
    {
        Task<List<Alarm>> GetActiveAlarmsByTypeAsync(string type);
        Task<bool> GetActiveAlarmsExistByTypeAsync(string type);
        Task<List<Alarm>> GetActiveAlarmsAsync();
        void DismissAlarms(List<Alarm> alarms);
        void DismissAlarm(Alarm alarm);
        Task<List<Alarm>> GetAlarmsByTypeAsync(string alarmType);
    }
}