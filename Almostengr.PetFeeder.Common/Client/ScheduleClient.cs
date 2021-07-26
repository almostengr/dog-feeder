using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client
{
    public class ScheduleClient : BaseClient, IScheduleClient
    {
        public async Task<Uri> CreateScheduleAsync(ScheduleDto schedule)
        {
            return await CreateAsync<ScheduleDto>("/schedules", schedule);
        }

        public async Task<HttpStatusCode> DeleteScheduleAsync(int id)
        {
            return await DeleteAsync<ScheduleDto>($"/schedules/{id}");
        }

        public async Task<IList<ScheduleDto>> GetActiveSchedulesAsync()
        {
            return await GetAsync<IList<ScheduleDto>>("/schedules");
        }

        public async Task<IList<ScheduleDto>> GetAllSchedulesAsync()
        {
            return await GetAsync<IList<ScheduleDto>>("/schedules/all");
        }

        public async Task<IList<ScheduleDto>> GetInactiveSchedulesAsync()
        {
            return await GetAsync<IList<ScheduleDto>>("/schedules/inactive");
        }

        public async Task<ScheduleDto> GetScheduleAsync(int id)
        {
            return await GetAsync<ScheduleDto>($"/schedules/{id}");
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto schedule)
        {
            return await UpdateAsync<ScheduleDto>("/schedules", schedule);
        }
    }
}