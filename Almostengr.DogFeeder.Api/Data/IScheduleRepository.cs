using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Models;

namespace Almostengr.DogFeeder.Api.Data
{
    public interface IScheduleRepository
    {
        Task Create(Schedule entity);
        void DeleteSchedule(Schedule schedule);
        Task<List<Schedule>> GetAllSchedulesAsync();
        Task<Schedule> GetScheduleAsync(int id);
        Task SaveChangesAsync();
    }
}