using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;

namespace Almostengr.PetFeeder.Web.Repository
{
    public interface IScheduleRepository : IRepositoryBase<Schedule>
    {
        Task<List<Schedule>> GetAllActiveSchedulesAsync();
        Task<Schedule> GetByIdAsync(int id);
        Task<List<Schedule>> GetOldOneTimeSchedulesAsync();
    }
}