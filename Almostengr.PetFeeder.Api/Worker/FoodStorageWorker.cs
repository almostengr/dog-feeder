using System;
using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{

    public class FoodStorageWorker : BaseWorker, IFoodStorageWorker
    {
        private readonly GpioController _gpio;
        private readonly ILogger<FoodStorageWorker> _logger;
        private readonly IAlarmRepository _alarmRepo;
        
        private const int triggerPin = 4;
        private const int echoPin = 5;

        public FoodStorageWorker(ILogger<FoodStorageWorker> logger, GpioController gpio, IAlarmRepository alarmRepo) :
             base(logger, gpio)
        {
            _gpio = gpio;
            _logger = logger;
            _alarmRepo = alarmRepo;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _gpio.OpenPin(triggerPin, PinMode.Output);
            _gpio.OpenPin(echoPin, PinMode.Input);

            _gpio.Write(triggerPin, GpioOff);

            Task.Delay(TimeSpan.FromSeconds(1));

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _gpio.ClosePin(triggerPin);
            _gpio.ClosePin(echoPin);

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                double distance = GetDistance();

                await ShowFoodLevelMessage(distance);

                await Task.Delay(TimeSpan.FromMinutes(30));
            }
        }

        public async Task ShowFoodLevelMessage(double distance)
        {
            if (distance <= 15)
            {
                string message = "Food level is low. Please refill";

                Alarm alarm = AlarmTriggered(nameof(FoodStorageWorker), message);
                await _alarmRepo.CreateAlarmAsync(alarm);
            }
        }

        public double GetDistance()
        {
            _logger.LogInformation("Geting distance");

            _gpio.Write(triggerPin, GpioOn); // set trigger to high

            Task.Delay(TimeSpan.FromMilliseconds(5));

            _gpio.Write(triggerPin, GpioOff); // set trigger to low

            DateTime startTime = DateTime.Now,
                endTime = DateTime.Now;

            // save start time
            while (_gpio.Read(echoPin) == 0)
            {
                startTime = DateTime.Now;
            }

            // save end time
            while (_gpio.Read(echoPin) == 1)
            {
                endTime = DateTime.Now;
            }

            TimeSpan elapsedTime = endTime.TimeOfDay - startTime.TimeOfDay;

            double distance = (elapsedTime.TotalMilliseconds * 0.0343) / 2;

            _logger.LogInformation("Distance: " + distance);

            return distance;
        }

    }
}