using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client
{
    public class AlarmClient : BaseClient, IAlarmClient
    {
        public async Task<AlarmDto> CreateAlarmAsync(AlarmDto alarmDto)
        {
            return await PostAsync<AlarmDto>("/api/alarms", alarmDto);
        }

        public async Task<AlarmDto> UpdateAlarmAsync(AlarmDto alarmDto)
        {
            return await PutAsync<AlarmDto>("/api/alarms", alarmDto);
        }

        public async Task<IList<AlarmDto>> GetActiveAlarmsAsync()
        {
            return await GetAsync<IList<AlarmDto>>("/api/alarms");
        }

        public async Task<AlarmDto> GetAlarmAsync(int id)
        {
            return await GetAsync<AlarmDto>($"/api/alarms/{id}");
        }

        public async Task<IList<AlarmDto>> GetAllAlarmsAsync()
        {
            return await GetAsync<IList<AlarmDto>>("/api/alarms/all");
        }

        public async Task<IList<AlarmDto>> GetActiveAlarmsByTypeAsync(string alarmType)
        {
            return await GetAsync<IList<AlarmDto>>($"/api/alarms/type/{alarmType}");
        }

    }
}