using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Constants;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class FoodStorageInputSensor : InputSensorBase, IFoodStorageInputSensor
    {
        private readonly ILogger<FoodStorageInputSensor> _logger;
        private readonly GpioController _gpio;


        public FoodStorageInputSensor(ILogger<FoodStorageInputSensor> logger, GpioController gpio) : base(logger, gpio)
        {
            _logger = logger;
            _gpio = gpio;
        }

        // public double GetDistance()
        public bool IsFoodStorageLevelLow()
        {
            _logger.LogInformation("Geting distance");

            _gpio.Write(TriggerPin, GpioOutput.On); // set trigger to high

            Task.Delay(TimeSpan.FromMilliseconds(5));

            _gpio.Write(TriggerPin, GpioOutput.Off); // set trigger to low

            DateTime startTime = DateTime.Now, endTime = DateTime.Now;

            // save start time
            while (_gpio.Read(EchoPin) == 0)
            {
                startTime = DateTime.Now;
            }

            // save end time
            while (_gpio.Read(EchoPin) == 1)
            {
                endTime = DateTime.Now;
            }

            TimeSpan elapsedTime = endTime.TimeOfDay - startTime.TimeOfDay;

            double distance = (elapsedTime.TotalMilliseconds * 0.0343) / 2;

            _logger.LogInformation("Distance: " + distance);

            // return distance;

            // TODO check distance number and adjust
            if (distance <= 4.0){
                return true;
            }

            return false;
        }
    }
}