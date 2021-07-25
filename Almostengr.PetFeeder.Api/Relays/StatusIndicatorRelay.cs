using System;
using System.Device.Gpio;
using Almostengr.PetFeeder.Api.Constants;
using Almostengr.PetFeeder.Api.Relays;
using Microsoft.Extensions.Logging;

namespace AlmostEngr.PetFeeder.Api.Relays
{
    public class StatusIndicatorRelay : RelayBase
    {
        private readonly ILogger<StatusIndicatorRelay> _logger;
        private readonly GpioController _gpio;

        public StatusIndicatorRelay(ILogger<StatusIndicatorRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPins(gpio, PinMode.Output, new Int32[] { GpioPin.StatusOkRelay, GpioPin.StatusErrorRelay });
        }

        public void StatusOk()
        {
            _gpio.Write(GpioPin.StatusErrorRelay, GpioOutput.Off);
            _gpio.Write(GpioPin.StatusOkRelay, GpioOutput.On);
        }

        public void StatusAlert()
        {
            _gpio.Write(GpioPin.StatusErrorRelay, GpioOutput.On);
            _gpio.Write(GpioPin.StatusOkRelay, GpioOutput.Off);
        }
    }
}