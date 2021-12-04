using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd
{
    public class MockFoodBowlService : IFoodBowlService
    {
        private readonly IFoodBowlRepository _repository;
        private readonly IFoodBowlRelay _relay;

        public MockFoodBowlService(IFoodBowlRepository repository, IFoodBowlRelay relay)
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
            await _relay.RunMotorForwardAsync(feedingDto.Amount);
            return await _repository.AddFeedingAsync(feedingDto);
        }
    }
}