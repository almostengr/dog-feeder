using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IScheduleClient{

        Task<Schedule> GetAsync(int id);
        Task<IList<Schedule>> GetAllSchedulesAsync();
        Task<IList<Schedule>> GetActiveSchedulesAsync();
        Task<Schedule> CreateScheduleAsync(Schedule Schedule);
        Task<Schedule> UpdateScheduleAsync(Schedule Schedule);
        Task<bool> DeleteScheduleAsync(int id);
    }
}