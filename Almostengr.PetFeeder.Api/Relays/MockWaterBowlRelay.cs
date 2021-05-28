using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Relays
{
    public class MockWaterBowlRelay : MockRelayBase, IWaterBowlRelay
    {
        private readonly ILogger<MockWaterBowlRelay> _logger;

        public MockWaterBowlRelay(ILogger<MockWaterBowlRelay> logger) : base(logger)
        {
            _logger = logger;
        }

        public void CloseWaterValve()
        {
            _logger.LogInformation("Closing water valve");
        }

        public void OpenWaterValve()
        {
            _logger.LogInformation("Opening water valve");
        }
    }
}