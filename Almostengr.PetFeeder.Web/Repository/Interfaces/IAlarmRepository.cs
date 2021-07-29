using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;

namespace Almostengr.PetFeeder.Web.Repository
{
    public interface IAlarmRepository : IRepositoryBase<Alarm>
    {
        Task<List<Alarm>> GetActiveAlarmsAsync();
        void DismissAlarm(Alarm alarm);
        Task<List<Alarm>> GetAlarmsByTypeAsync(string alarmType);
        Task<Alarm> GetByIdAsync(int id);
        Task<IList<Alarm>> GetLatestAsync();
    }
}