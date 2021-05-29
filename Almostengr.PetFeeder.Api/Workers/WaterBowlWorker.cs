using System;
using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Relays;
using Almostengr.PetFeeder.Api.Repository;
using Almostengr.PetFeeder.Api.InputSensor;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Workers
{
    public class WaterBowlWorker : BaseWorker, IWaterBowlWorker
    {
        private readonly ILogger<WaterBowlWorker> _logger;
        private readonly IWaterBowlRelay _relay;
        private readonly IWaterInputSensor _sensor;
        private readonly IWateringRepository _repository;

        public WaterBowlWorker(ILogger<WaterBowlWorker> logger, IWateringRepository repository,
            IWaterBowlRelay relay, IWaterInputSensor sensor) : base(logger)
        {
            _logger = logger;
            _repository = repository;
            _relay = relay;
            _sensor = sensor;
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
                    Watering watering = null;
                    bool isWaterLow = _sensor.IsWaterBowlLow();

                    if (currentTime >= earliestTime && currentTime <= latestTime && isWaterLow == true)
                    {
                        watering = RefillWaterBowl();
                    }

                    _relay.CloseWaterValve();
                    await _repository.CreateAsync(watering);
                    await _repository.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _relay.CloseWaterValve();
                    _logger.LogError(ex.Message);
                }

                await Task.Delay(TimeSpan.FromMinutes(MonitorWorkerDelayMins), stoppingToken);
            }
        }

        public Watering RefillWaterBowl()
        {
            bool isWaterLow = _sensor.IsWaterBowlLow();
            Watering watering = new Watering();
            int counter = 0;

            while (isWaterLow && counter <= 16)
            {
                watering.Timestamp = DateTime.Now;

                _relay.OpenWaterValve();

                Task.Delay(TimeSpan.FromMilliseconds(250));

                isWaterLow = _sensor.IsWaterBowlLow();

                counter++; // to prevent bowl from overflowing
            }

            _relay.CloseWaterValve();

            return watering;
        }

    }
}