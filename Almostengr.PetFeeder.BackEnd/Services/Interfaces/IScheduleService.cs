using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<ScheduleDto> GetScheduleAsync(int id);
        Task<List<ScheduleDto>> GetAllSchedules();
        Task<List<ScheduleDto>> GetSchedulesByTimeAsync(TimeSpan scheduledTime);
        Task<ScheduleDto> CreateScheduleAsync(ScheduleDto scheduleDto);
        Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto scheduleDto);
        Task DeleteScheduleAsync(int id);
        Task<List<ScheduleDto>> GetScheduleForCurrentTimeAsync();
    }
}