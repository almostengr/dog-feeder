using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface IScheduleClient
    {
        Task<ScheduleDto> GetScheduleAsync(int id);
        Task<IList<ScheduleDto>> GetAllSchedulesAsync();
        Task<IList<ScheduleDto>> GetActiveSchedulesAsync();
        Task<IList<ScheduleDto>> GetInactiveSchedulesAsync();
        Task<ScheduleDto> CreateScheduleAsync(ScheduleDto scheduleDto);
        Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto scheduleDto);
        Task<HttpStatusCode> DeleteScheduleAsync(int id);
    }
}