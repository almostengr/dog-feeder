using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;
        private readonly ILogger<ScheduleService> _logger;

        public ScheduleService(IScheduleRepository repository, ILogger<ScheduleService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ScheduleDto> CreateScheduleAsync(ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return null;
            }

            Schedule schedule = new Schedule(scheduleDto);
            schedule.Created = DateTime.Now;
            schedule.Modified = schedule.Created;

            return await _repository.CreateScheduleAsync(schedule);
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            ScheduleDto scheduleDto = await _repository.GetScheduleAsync(id);

            if (scheduleDto == null)
            {
                _logger.LogError($"Schedule with id {id} does not exist");
                return false;
            }

            Schedule schedule = new Schedule(scheduleDto);
            return await _repository.DeleteScheduleAsync(schedule);
        }

        public async Task<ScheduleDto> GetScheduleAsync(int id)
        {
            return await _repository.GetScheduleAsync(id);
        }

        public async Task<List<ScheduleDto>> GetSchedulesAsync()
        {
            return await _repository.GetSchedulesAsync();
        }

        public async Task<List<ScheduleDto>> GetSchedulesByTimeAsync(TimeSpan time)
        {
            return await _repository.GetSchedulesByTimeAsync(time);
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto scheduleDto)
        {
            Schedule schedule = await _repository.GetScheduleEntity(scheduleDto.ScheduleId);

            if (schedule == null)
            {
                _logger.LogError($"Schedule with id {scheduleDto.ScheduleId} does not exist");
                return null;
            }

            schedule.Modified = DateTime.Now;
            schedule.FeedingAmount = scheduleDto.FeedingAmount;
            schedule.IsActive = scheduleDto.IsActive;
            // schedule.ScheduleType = (ScheduleType)scheduleDto.ScheduleType;
            schedule.ScheduledTime = scheduleDto.ScheduledTime;

            return await _repository.UpdateScheduleAsync(schedule);
        }


    }
}