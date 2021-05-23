using System;
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

        public WaterBowlWorker(ILogger<WaterBowlWorker> logger, IWateringRepository wateringRepository) : base(logger)
        {
            _logger = logger;
            _wateringRepository = wateringRepository;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            // initialize GPIO pins 

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            CloseWaterValve();

            // release GPIO pins

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

        public bool IsWaterBowlFull()
        {
            // check if GPIO has continunity

            return true;
        }

        public async Task DoOpenWaterValve()
        {
            bool isWaterLow = false;
            isWaterLow = IsWaterBowlFull();

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
            while (isWaterLow && counter <= 20)
            {
                // open water valve

                await Task.Delay(TimeSpan.FromSeconds(0.5));
                isWaterLow = IsWaterBowlFull();
                counter++;
            }

            _wateringRepository.UpdateWatering(watering);
            await _wateringRepository.SaveChangesAsync();
        }

        public void CloseWaterValve()
        {
            // turn off water
            _logger.LogInformation("Turning off water");
        }

    }
}