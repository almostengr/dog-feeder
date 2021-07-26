using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IAlarmRepository : IRepositoryBase<Alarm>
    {
        Task<List<Alarm>> GetActiveAlarmsAsync();
        void DismissAlarm(Alarm alarm);
        Task<List<Alarm>> GetAlarmsByTypeAsync(string alarmType);
    }
}