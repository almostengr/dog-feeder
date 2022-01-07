using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Constants;
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
            try
            {
                Schedule schedule = new Schedule(scheduleDto);
                schedule.Created = DateTime.Now;
                schedule.Modified = schedule.Created;
                
                return await _repository.CreateScheduleAsync(schedule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<int> DeleteScheduleAsync(int id)
        {
            try
            {
                ScheduleDto scheduleDto = await _repository.GetScheduleAsync(id);

                if (scheduleDto == null)
                {
                    throw new ArgumentException($"Schedule with id {id} does not exist");
                }

                Schedule schedule = new Schedule(scheduleDto);
                await _repository.DeleteScheduleAsync(schedule);

                return TaskResult.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return TaskResult.Error;
            }
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
            try 
            {
                Schedule schedule = await _repository.GetScheduleEntity(scheduleDto.ScheduleId);

                if (schedule == null)
                {
                    throw new ArgumentException($"Schedule with id {scheduleDto.ScheduleId} does not exist");
                }

                schedule.Modified = DateTime.Now;
                schedule.FeedingAmount = scheduleDto.FeedingAmount;
                schedule.IsActive = scheduleDto.IsActive;
                // schedule.ScheduleType = (ScheduleType)scheduleDto.ScheduleType;
                schedule.ScheduledTime = scheduleDto.ScheduledTime;

                return await _repository.UpdateScheduleAsync(schedule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}