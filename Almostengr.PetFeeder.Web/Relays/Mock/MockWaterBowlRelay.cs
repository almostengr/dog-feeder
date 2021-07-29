using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Relays
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
            Task.Delay(TimeSpan.FromSeconds(1));
        }

        public void OpenWaterValve()
        {
            _logger.LogInformation("Opening water valve");
            Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}