using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Relays;
using Almostengr.PetFeeder.BackEnd.Repository;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class FeedingService : IFeedingService
    {
        private readonly IFeedingRepository _repository;
        private readonly ILogger<FeedingService> _logger;
        private readonly IFeedingRelay _relay;

        public FeedingService(IFeedingRepository repository, ILogger<FeedingService> logger, 
            IFeedingRelay relay)
        {
            _repository = repository;
            _logger = logger;
            _relay = relay;
        }

        public async Task<FeedingDto> CreateFeedingAsync(FeedingDto feedingDto)
        {
            Feeding feeding = new Feeding(feedingDto);
            feeding.Created = DateTime.Now;

            var dispensedFood = await _relay.FeedMeAsync(feeding.Amount);
            
            if (dispensedFood)
            {
                _logger.LogInformation($"Feeding of {feeding.Amount} seconds dispensed");   
                return await _repository.CreateFeedingAsync(feeding);
            }

            return null;
        }

        public async Task<FeedingDto> GetFeedingAsync(int id)
        {
            return await _repository.GetFeedingAsync(id);
        }

        public async Task<List<FeedingDto>> GetFeedingsAsync()
        {
            return await _repository.GetFeedingsAsync();
        }
    }
}