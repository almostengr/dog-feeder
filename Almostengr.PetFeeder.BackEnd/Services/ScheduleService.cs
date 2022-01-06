using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Repository.Interfaces;

namespace Almostengr.PetFeeder.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ScheduleDto> CreateScheduleAsync(ScheduleDto scheduleDto)
        {
            Schedule schedule = new Schedule(scheduleDto);
            scheduleDto.Created = DateTime.Now;
            scheduleDto.Modified = DateTime.Now;
            
            return await _repository.CreateScheduleAsync(schedule);
        }

        public async Task DeleteScheduleAsync(int id)
        {
            ScheduleDto scheduleDto = await _repository.GetScheduleAsync(id);

            if (scheduleDto == null)
            {
                throw new ArgumentException($"Schedule with id {id} does not exist");
            }

            Schedule schedule = new Schedule(scheduleDto);
            await _repository.DeleteScheduleAsync(schedule);
        }

        public async Task<ScheduleDto> GetScheduleAsync(int id)
        {
            return await _repository.GetScheduleAsync(id);
        }

        public async Task<List<ScheduleDto>> GetSchedulesAsync()
        {
            return await _repository.GetSchedulesAsync();
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto scheduleDto)
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
    }
}