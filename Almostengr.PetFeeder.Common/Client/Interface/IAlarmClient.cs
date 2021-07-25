using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IAlarmClient
    {
        Task<IList<Alarm>> GetActiveAlarmsAsync();
        Task<IList<Alarm>> GetAllAlarmsAsync();
        Task<IList<Alarm>> GetActiveAlarmsByTypeAsync(string alarmType);
        Task<Alarm> GetAlarmAsync(int id);
        Task<Alarm> DismissActiveAlarmAsync(int id);
        Task<Uri> CreateAlarmAsync(Alarm alarm);
    }
}