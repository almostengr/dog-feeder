using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class MockWaterBowlService : IWaterBowlService
    {
        private readonly ILogger<MockWaterBowlService> _logger;
        private readonly IWaterBowlRepository _repository;
        private readonly IWaterBowlRelay _waterBowlRelay;
        private readonly IWaterLevelRelay _waterLevelRelay;

        public MockWaterBowlService(
            ILogger<MockWaterBowlService> logger,
            IWaterBowlRepository repository, IWaterBowlRelay waterBowlRelay, IWaterLevelRelay waterLevelRelay)
        {
            _logger = logger;
            _repository = repository;
            _waterBowlRelay = waterBowlRelay;
            _waterLevelRelay = waterLevelRelay;
        }

        public async Task<WaterBowlDto> AddWaterBowlAsync(WaterBowlDto waterBowl)
        {
            // check water level 

            // if water level is low, then add water
            // else do nothing 

            // add entry to database with amount of water added

            // return fille performed

            return new();
        }

        public async Task<List<WaterBowlDto>> GetAllWateringsAsync()
        {
            return await _repository.GetAllWaterings();
        }

        public async Task<List<WaterBowlDto>> GetRecentWateringsAsync()
        {
            return await _repository.GetRecentWaterings();
        }

        public async Task<WaterBowlDto> GetWaterBowlAsync(int id)
        {
            return await _repository.GetWaterBowlAsync(id);
        }
    }
}