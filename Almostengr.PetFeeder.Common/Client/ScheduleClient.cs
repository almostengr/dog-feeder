using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class ScheduleClient : BaseClient, IScheduleClient
    {
        public async Task<Uri> CreateScheduleAsync(Schedule schedule)
        {
            return await CreateAsync<Schedule>("/schedules", schedule);
        }

        public async Task<HttpStatusCode> DeleteScheduleAsync(int id)
        {
            return await DeleteAsync<Schedule>($"/schedules/{id}");
        }

        public async Task<IList<Schedule>> GetActiveSchedulesAsync()
        {
            return await GetAsync<IList<Schedule>>("/schedules");
        }

        public async Task<IList<Schedule>> GetAllSchedulesAsync()
        {
            return await GetAsync<IList<Schedule>>("/schedules/all");
        }

        public async Task<IList<Schedule>> GetInactiveSchedulesAsync()
        {
            return await GetAsync<IList<Schedule>>("/schedules/inactive");
        }

        public async Task<Schedule> GetScheduleAsync(int id)
        {
            return await GetAsync<Schedule>($"/schedules/{id}");
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            return await UpdateAsync<Schedule>("/schedules", schedule);
        }
    }
}