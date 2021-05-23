using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IAlarmRepository : IBaseRepository
    {
        Task CreateAlarmAsync(Alarm alarm);
        Task<List<Alarm>> GetActiveAlarmsAsync();
        Task<Alarm> GetAlarmByIdAsync(int id);
        Task<List<Alarm>> GetAllAlarmsAsync();
        void UpdateAlarm(Alarm alarm);
        void UpdateAlarms(List<Alarm> alarms);
    }
}