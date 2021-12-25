using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class WateringService : IWateringService
    {
        private readonly ILogger<WateringService> _logger;
        private readonly IWateringRepository _repository;

        public WateringService(ILogger<WateringService> logger, IWateringRepository repository, 
            IWaterBowlRelay _bowlRelay, IWaterLevelRelay _levelRelay)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<WateringDto> CreateWateringAsync(WateringDto wateringDto)
        {

            return await _repository.CreateWateringAsync(wateringDto);
        }

        public async Task<List<WateringDto>> GetAllWateringsAsync()
        {
            return await _repository.GetAllWateringsAsync();
        }

        public async Task<WateringDto> GetWateringAsync(int id)
        {
            return await _repository.GetWateringAsync(id);
        }
    }
}