using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Models;

namespace Almostengr.PetFeeder.Api.Data
{
    public interface IScheduleRepository
    {
        Task CreateSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(Schedule schedule);
        Task<List<Schedule>> GetAllSchedulesAsync();
        Task<Schedule> GetScheduleByIdAsync(int id);
        Task SaveChangesAsync();
        Task<List<Schedule>> GetAllActiveSchedulesAsync();
        Task<List<Schedule>>  GetAllInactiveSchedulesAsync();
    }
}