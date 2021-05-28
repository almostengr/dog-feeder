using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Constants;
using Almostengr.PetFeeder.Api.Models;
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

        public Alarm AlarmTriggered(string type, string message)
        {
            Alarm alarm = new Alarm();
            alarm.Created = DateTime.Now;
            alarm.IsActive = true;
            alarm.Message = message;
            alarm.Type = type;

            _logger.LogWarning(message);

            return alarm;
        }
    }
}
