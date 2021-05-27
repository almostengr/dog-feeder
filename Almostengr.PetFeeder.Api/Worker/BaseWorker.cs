using System;
using System.Device.Gpio;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public abstract class BaseWorker : BackgroundService
    {
        private readonly ILogger<BaseWorker> _logger;
        private readonly GpioController _gpio;
        internal PinValue GpioOn = PinValue.High;
        internal PinValue GpioOff = PinValue.Low;
        internal Uri ApiUri = new Uri("https://localhost:5000");

        protected BaseWorker(ILogger<BaseWorker> logger, GpioController gpio)
        {
            _logger = logger;
            _gpio = gpio;
        }

        internal bool IsWaterLevelLow(int vccPinNumber, int gndPinNumber)
        {
            _gpio.Write(vccPinNumber, GpioOn);

            var sensorResult = _gpio.Read(gndPinNumber);

            _gpio.Write(vccPinNumber, GpioOff);

            if (sensorResult == GpioOff)
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