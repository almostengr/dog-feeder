using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Relays.Mock
{
    public class MockFoodBowlRelay : MockRelayBase, IFoodBowlRelay
    {
        private readonly ILogger<MockFoodBowlRelay> _logger;

        public MockFoodBowlRelay(ILogger<MockFoodBowlRelay> logger) : base(logger)
        {
            _logger = logger;
        }

        public async Task<FeedingDto> PerformFeeding(FeedingDto feedingDto)
        {
            _logger.LogInformation("Performing feeding");
            await Task.Delay(TimeSpan.FromSeconds(5));

            return feedingDto;
        }
    }
}