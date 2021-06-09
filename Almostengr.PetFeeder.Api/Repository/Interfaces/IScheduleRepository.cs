using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IScheduleRepository : IRepositoryBase<Schedule>
    {
        Task<List<Schedule>> GetAllActiveSchedulesAsync();
        Task<List<Schedule>> GetAllInactiveSchedulesAsync();
    }
}