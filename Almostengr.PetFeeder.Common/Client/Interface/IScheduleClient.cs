using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IScheduleClient
    {
        Task<Schedule> GetScheduleAsync(int id);
        Task<IList<Schedule>> GetAllSchedulesAsync();
        Task<IList<Schedule>> GetActiveSchedulesAsync();
        Task<IList<Schedule>> GetInactiveSchedulesAsync();
        Task<Uri> CreateScheduleAsync(Schedule schedule);
        Task<Schedule> UpdateScheduleAsync(Schedule schedule);
        Task<HttpStatusCode> DeleteScheduleAsync(int id);
    }
}