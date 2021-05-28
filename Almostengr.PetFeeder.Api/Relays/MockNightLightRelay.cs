using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Relays
{
    public class MockNightLightRelay : MockRelayBase, INightLightRelay
    {
        private readonly ILogger<MockNightLightRelay> _logger;

        public MockNightLightRelay(ILogger<MockNightLightRelay> logger) : base(logger)
        {
            _logger = logger;
        }

        public async Task NightLightOffAsync()
        {
            _logger.LogInformation("night light off");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        public async Task NightLightOnAsync()
        {
            _logger.LogInformation("Night light on");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}