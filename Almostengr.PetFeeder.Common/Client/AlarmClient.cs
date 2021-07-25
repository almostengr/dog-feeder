using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class AlarmClient : BaseClient, IAlarmClient
    {
        public async Task<Uri> CreateAlarmAsync(Alarm alarm)
        {
            // return await CreateAsync<Alarm>("/alarms", alarm);
            return await CreateAsync<Alarm>("/alarms", alarm);
        }

        public async Task<Alarm> DismissActiveAlarmAsync(int id)
        {
            return await GetAsync<Alarm>($"/alarms/{id}/dismiss");
        }

        public async Task<IList<Alarm>> GetActiveAlarmsAsync()
        {
            return await GetAsync<IList<Alarm>>("/alarms");
        }

        public async Task<Alarm> GetAlarmAsync(int id)
        {
            return await GetAsync<Alarm>($"/alarms/{id}");
        }

        public async Task<IList<Alarm>> GetAllAlarmsAsync()
        {
            return await GetAsync<IList<Alarm>>("/alarms/all");
        }

        public async Task<IList<Alarm>> GetActiveAlarmsByTypeAsync(string alarmType)
        {
            return await GetAsync<IList<Alarm>>($"/alarms/type/{alarmType}");
        }

    }
}