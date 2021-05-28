using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IAlarmRepository : IRepositoryBase<Alarm>
    {
        // Task CreateAlarmAsync(Alarm alarm);
        Task<bool> GetActiveAlarmsExistByTypeAsync(string type);
        Task<List<Alarm>> GetActiveAlarmsAsync();
        // Task<Alarm> GetAlarmByIdAsync(int id);
        // Task<List<Alarm>> GetAllAlarmsAsync();
        // void UpdateAlarm(Alarm alarm);
        // void UpdateAlarms(List<Alarm> alarms);
        void DismissAlarm(Alarm alarm);
    }
}