using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client
{
    public class ScheduleClient : BaseClient, IScheduleClient
    {
        public async Task<ScheduleDto> CreateScheduleAsync(ScheduleDto scheduleDto)
        {
            return await PostAsync<ScheduleDto>("/api/schedules", scheduleDto);
        }

        public async Task<HttpStatusCode> DeleteScheduleAsync(int id)
        {
            return await DeleteAsync<ScheduleDto>($"/api/schedules/{id}");
        }

        public async Task<IList<ScheduleDto>> GetActiveSchedulesAsync()
        {
            return await GetAsync<IList<ScheduleDto>>("/api/schedules");
        }

        public async Task<IList<ScheduleDto>> GetAllSchedulesAsync()
        {
            return await GetAsync<IList<ScheduleDto>>("/api/schedules/all");
        }

        public async Task<IList<ScheduleDto>> GetInactiveSchedulesAsync()
        {
            return await GetAsync<IList<ScheduleDto>>("/api/schedules/inactive");
        }

        public async Task<ScheduleDto> GetScheduleAsync(int id)
        {
            return await GetAsync<ScheduleDto>($"/api/schedules/{id}");
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto scheduleDto)
        {
            return await PutAsync<ScheduleDto>("/api/schedules", scheduleDto);
        }
    }
}