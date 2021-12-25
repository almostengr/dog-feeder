using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface IScheduleRepository
    {
        Task<ScheduleDto> AddSchedule(ScheduleDto schedule);
        Task<bool> DeleteSchedule(int id);
        Task<ScheduleDto> UpdateSchedule(ScheduleDto schedule);
        Task<List<ScheduleDto>> GetSchedules();
        Task<ScheduleDto> GetSchedule(int id);
        Task<List<ScheduleDto>> GetSchedulesForCurrentTimeAsync();
        Task SaveChangesAsync();
    }
}