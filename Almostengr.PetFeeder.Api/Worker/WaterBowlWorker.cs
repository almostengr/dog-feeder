using System;
using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class WaterBowlWorker : BaseWorker, IWaterBowlWorker
    {
        private readonly ILogger<WaterBowlWorker> _logger;
        private readonly IWateringRepository _wateringRepository;
        private readonly GpioController _gpio;
        
        private const int WaterBowlVcc = 20;
        private const int WaterBowlGnd = 21;
        private const int WaterRelay = 25;

        public WaterBowlWorker(ILogger<WaterBowlWorker> logger, IWateringRepository wateringRepository,
            GpioController gpio) : base(logger, gpio)
        {
            _logger = logger;
            _wateringRepository = wateringRepository;
            _gpio = gpio;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            // initialize GPIO pins
            _gpio.OpenPin(WaterBowlVcc, PinMode.Output);
            _gpio.OpenPin(WaterBowlGnd, PinMode.Input);
            _gpio.OpenPin(WaterRelay, PinMode.Output);

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            CloseWaterValve();

            // release GPIO pins
            _gpio.ClosePin(WaterBowlVcc);
            _gpio.ClosePin(WaterBowlGnd);
            _gpio.ClosePin(WaterRelay);

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan earliestTime = new TimeSpan(06, 00, 00);
            TimeSpan latestTime = new TimeSpan(19, 00, 00);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    TimeSpan currentTime = DateTime.Now.TimeOfDay;

                    if (currentTime >= earliestTime && currentTime <= latestTime)
                    {
                        await DoOpenWaterValve();
                    }

                    CloseWaterValve();
                }
                catch (Exception ex)
                {
                    CloseWaterValve();
                    _logger.LogError(ex.Message);
                }

                await Task.Delay(TimeSpan.FromHours(1));
            }
        }

        public async Task DoOpenWaterValve()
        {
            bool isWaterLow = false;
            isWaterLow = IsWaterLevelLow();

            Watering watering = null;

            if (isWaterLow)
            {
                _logger.LogInformation("Turning on water");

                watering = new Watering();
                watering.Timestamp = DateTime.Now;
                await _wateringRepository.CreateWateringAsync(watering);
                await _wateringRepository.SaveChangesAsync();
            }

            int counter = 0;
            while (isWaterLow && counter <= 10)
            {
                _gpio.Write(WaterRelay, GpioOn); // open water valve

                await Task.Delay(TimeSpan.FromSeconds(0.5));
                isWaterLow = IsWaterLevelLow();
                counter++;
            }

            _wateringRepository.UpdateWatering(watering);
            await _wateringRepository.SaveChangesAsync();
        }

        public void CloseWaterValve()
        {
            _logger.LogInformation("Turning off water");
            _gpio.Write(WaterRelay, GpioOff); // turn off water
        }

        public bool IsWaterLevelLow()
        {
            return base.IsWaterLevelLow(WaterBowlVcc, WaterBowlGnd);
        }

    }
}