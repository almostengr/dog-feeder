using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class FoodBowlService : IFoodBowlService
    {
        private readonly IFoodBowlRepository _repository;
        private readonly IFoodBowlRelay _relay;

        public FoodBowlService(IFoodBowlRepository repository, IFoodBowlRelay relay)
        {
            _repository = repository;
            _relay = relay;
        }

        public async Task<FeedingDto> GetFeedingAsync(int id)
        {
            return await _repository.GetFeedingAsync(id);
        }

        public async Task<List<FeedingDto>> GetFeedingsAsync()
        {
            return await _repository.GetAllFeedingsAsync();
        }

        public async Task<List<FeedingDto>> GetRecentFeedingsAsync()
        {
            return await _repository.GetRecentFeedingsAsync();
        }

        public async Task<FeedingDto> PerformFeedingAsync(FeedingDto feedingDto)
        {
            await _relay.RunMotorBackwardAsync(0.5);
            await _relay.RunMotorForwardAsync(0.5);
            await _relay.RunMotorBackwardAsync(0.5);
            await _relay.RunMotorForwardAsync(feedingDto.Amount);
            await _relay.RunMotorBackwardAsync(0.5);
            await _relay.RunMotorForwardAsync(0.5);

            feedingDto.Created = DateTime.Now;

            FeedingDto response = await _repository.AddFeedingAsync(feedingDto);
            return response;
        }
    }
}