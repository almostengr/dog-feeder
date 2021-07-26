using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IScheduleClient
    {
        Task<ScheduleDto> GetScheduleAsync(int id);
        Task<IList<ScheduleDto>> GetAllSchedulesAsync();
        Task<IList<ScheduleDto>> GetActiveSchedulesAsync();
        Task<IList<ScheduleDto>> GetInactiveSchedulesAsync();
        Task<Uri> CreateScheduleAsync(ScheduleDto schedule);
        Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto schedule);
        Task<HttpStatusCode> DeleteScheduleAsync(int id);
    }
}