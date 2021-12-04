using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class MockScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public MockScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ScheduleDto> CreateScheduleAsync(ScheduleDto scheduleDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteScheduleAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ScheduleDto>> GetAllSchedules()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ScheduleDto> GetScheduleAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ScheduleDto>> GetScheduleForCurrentTimeAsync()
        {
            return await _repository.GetSchedulesForCurrentTimeAsync();
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto scheduleDto)
        {
            throw new System.NotImplementedException();
        }
    }
}