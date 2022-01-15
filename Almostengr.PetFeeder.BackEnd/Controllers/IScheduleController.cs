using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public interface IScheduleController : IBaseApiController
    {
        Task<IActionResult> CreateSchedule(ScheduleDto scheduleDto);
        Task<IActionResult> DeleteSchedule(int id);
        Task<IActionResult> GetSchedule(int id);
        Task<IActionResult> GetSchedules();
        Task<IActionResult> UpdateSchedule(ScheduleDto schedule);
    }
}