using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IAlarmClient
    {
        Task<IList<AlarmDto>> GetActiveAlarmsAsync();
        Task<IList<AlarmDto>> GetAllAlarmsAsync();
        Task<IList<AlarmDto>> GetActiveAlarmsByTypeAsync(string alarmType);
        Task<AlarmDto> GetAlarmAsync(int id);
        Task<AlarmDto> DismissActiveAlarmAsync(int id);
        Task<Uri> CreateAlarmAsync(AlarmDto alarm);
    }
}