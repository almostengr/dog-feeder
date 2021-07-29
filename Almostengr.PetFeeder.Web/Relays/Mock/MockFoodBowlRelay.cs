using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Relays
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