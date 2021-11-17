using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Relays.Mock
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
            Task.Delay(TimeSpan.FromMilliseconds(500));
        }

        public void ClosePins(GpioController gpio, int[] pins)
        {
            _logger.LogInformation("Closing pins");
            Task.Delay(TimeSpan.FromMilliseconds(500));
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int pin)
        {
            _logger.LogInformation("Open pin");
            Task.Delay(TimeSpan.FromMilliseconds(500));
        }

        public void OpenPins(GpioController gpio, PinMode pinMode, int[] pins)
        {
            _logger.LogInformation("Open pins");
            Task.Delay(TimeSpan.FromMilliseconds(500));
        }
    }
}