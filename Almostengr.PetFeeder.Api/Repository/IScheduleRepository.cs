using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IScheduleRepository : IBaseRepository
    {
        Task CreateScheduleAsync(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(Schedule schedule);
        Task<List<Schedule>> GetAllSchedulesAsync();
        Task<Schedule> GetScheduleByIdAsync(int? scheduleId);
        Task<List<Schedule>> GetAllActiveSchedulesAsync();
        Task<List<Schedule>> GetAllInactiveSchedulesAsync();
        Task<List<Schedule>> GetOldOneTimeSchedulesAsync();
    }
}