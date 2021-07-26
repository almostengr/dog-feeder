using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Constants;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class InputSensorBase : IInputSensorBase
    {
        private readonly GpioController _gpio;
        private readonly ILogger<InputSensorBase> _logger;

        public InputSensorBase(ILogger<InputSensorBase> logger, GpioController gpio)
        {
            _gpio = gpio;
            _logger = logger;
        }

        public bool IsWaterLevelLow(int vccPinNumber, int gndPinNumber)
        {
            _gpio.Write(vccPinNumber, GpioOutput.On);

            Task.Delay(TimeSpan.FromMilliseconds(250));

            var sensorResult = _gpio.Read(gndPinNumber);

            _gpio.Write(vccPinNumber, GpioOutput.Off);

            if (sensorResult == GpioOutput.Off)
            {
                return true;
            }

            return false;
        }

    }
}
