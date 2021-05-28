using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Constants;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Relays
{
    public class NightLightRelay : RelayBase, INightLightRelay
    {
        private const int LightRelay = 25;
        private readonly ILogger<NightLightRelay> _logger;
        private readonly GpioController _gpio;

        public NightLightRelay(ILogger<NightLightRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPin(gpio, PinMode.Output, LightRelay);
        }

        public async Task NightLightOnAsync()
        {
            _gpio.Write(LightRelay, GpioPin.On);
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }

        public async Task NightLightOffAsync()
        {
            _gpio.Write(LightRelay, GpioPin.Off);
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }
    }
}