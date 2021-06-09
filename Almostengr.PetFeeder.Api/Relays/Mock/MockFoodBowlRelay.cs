using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Relays
{
    public class MockFoodBowlRelay : MockRelayBase, IFoodBowlRelay
    {
        private readonly ILogger<MockFoodBowlRelay> _logger;

        public MockFoodBowlRelay(ILogger<MockFoodBowlRelay> logger) : base(logger)
        {
            _logger = logger;
        }

        public async Task<Feeding> PerformFeeding(Feeding feeding)
        {
            _logger.LogInformation("Performing feeding");
            await Task.Delay(TimeSpan.FromSeconds(5));

            return feeding;
        }
    }
}