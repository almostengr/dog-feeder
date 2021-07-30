using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Constants;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Relays
{
    public class NightLightRelay : RelayBase, INightLightRelay
    {
        private readonly ILogger<NightLightRelay> _logger;
        private readonly GpioController _gpio;

        public NightLightRelay(ILogger<NightLightRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPin(gpio, PinMode.Output, GpioPin.LightRelay);
        }

        public async Task NightLightOnAsync()
        {
            _gpio.Write(GpioPin.LightRelay, GpioOutput.On);
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }

        public async Task NightLightOffAsync()
        {
            _gpio.Write(GpioPin.LightRelay, GpioOutput.Off);
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }
    }
}