using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Repository.Interfaces
{
    public interface IScheduleRepository
    {
        Task<ScheduleDto> CreateScheduleAsync(Schedule schedule);
        Task<bool> DeleteScheduleAsync(Schedule schedule);
        Task<ScheduleDto> GetScheduleAsync(int id);
        Task<List<ScheduleDto>> GetSchedulesAsync();
        Task<Schedule> GetScheduleEntity(int scheduleId);
        Task<ScheduleDto> UpdateScheduleAsync(Schedule schedule);
        Task<List<ScheduleDto>> GetSchedulesByTimeAsync(TimeSpan time);
    }
}