using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Relays
{
    public class MockRelayBase : IRelayBase
    {
        private readonly ILogger<MockRelayBase> _logger;

        public MockRelayBase(ILogger<MockRelayBase> logger)
        {
            _logger = logger;
        }

        public void ClosePin(GpioController gpio, int pin)
        {
            _logger.LogInformation("Closing pin");
        }

        public void ClosePins(GpioController gpio, int[] pins)
        {
            _logger.LogInformation("Closing pins");
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int pin)
        {
            _logger.LogInformation("Open pin");
        }

        public void OpenPins(GpioController gpio, PinMode pinMode, int[] pins)
        {
            _logger.LogInformation("Open pins");
        }
    }
}