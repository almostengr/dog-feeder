using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client
{
    public class AlarmClient : BaseClient, IAlarmClient
    {
        public async Task<Uri> CreateAlarmAsync(AlarmDto alarm)
        {
            return await CreateAsync<AlarmDto>("/alarms", alarm);
        }

        public async Task<AlarmDto> DismissActiveAlarmAsync(int id)
        {
            return await GetAsync<AlarmDto>($"/alarms/{id}/dismiss");
        }

        public async Task<IList<AlarmDto>> GetActiveAlarmsAsync()
        {
            return await GetAsync<IList<AlarmDto>>("/alarms");
        }

        public async Task<AlarmDto> GetAlarmAsync(int id)
        {
            return await GetAsync<AlarmDto>($"/alarms/{id}");
        }

        public async Task<IList<AlarmDto>> GetAllAlarmsAsync()
        {
            return await GetAsync<IList<AlarmDto>>("/alarms/all");
        }

        public async Task<IList<AlarmDto>> GetActiveAlarmsByTypeAsync(string alarmType)
        {
            return await GetAsync<IList<AlarmDto>>($"/alarms/type/{alarmType}");
        }

    }
}