using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface IAlarmClient
    {
        Task<IList<AlarmDto>> GetActiveAlarmsAsync();
        Task<IList<AlarmDto>> GetAllAlarmsAsync();
        Task<IList<AlarmDto>> GetActiveAlarmsByTypeAsync(string alarmType);
        Task<AlarmDto> GetAlarmAsync(int id);
        Task<AlarmDto> CreateAlarmAsync(AlarmDto alarmDto);
        Task<AlarmDto> UpdateAlarmAsync(AlarmDto alarmDto);
    }
}