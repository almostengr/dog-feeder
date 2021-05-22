using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class WaterBowlMockWorker : BackgroundService, IWaterBowlWorker
    {
        private Random random;
        private readonly ILogger<WaterBowlMockWorker> _logger;

        public WaterBowlMockWorker(ILogger<WaterBowlMockWorker> logger)
        {
            _logger = logger;
            random = new Random();
        }

        public void CloseWaterValve()
        {
            _logger.LogInformation("Closing water valve");
        }

        public async Task DoOpenWaterValve()
        {
            bool isWaterLow = false; // set default value in case exception occurs
            isWaterLow = IsWaterBowlFull();

            if (isWaterLow)
            {
                Watering watering = new Watering();
                watering.Timestamp = DateTime.Now;

                _logger.LogInformation("Watering created");
                _logger.LogInformation("Save watering information");
            }

            int counter = 0;
            while (isWaterLow && counter <= 20)
            {
                _logger.LogInformation("Opening water valve");

                await Task.Delay(TimeSpan.FromSeconds(0.5));
                isWaterLow = IsWaterBowlFull();
                counter++;
            }

            CloseWaterValve();
        }

        public bool IsWaterBowlFull()
        {
            _logger.LogInformation("Checking if water bowl is full");

            if (random.Next(0, 10) <= 5)
            {
                return true;
            }

            return false;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan earliestTime = new TimeSpan(06, 00, 00);
            TimeSpan latestTime = new TimeSpan(19, 00, 00);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Checking water level");
                try
                {
                    TimeSpan currentTime = DateTime.Now.TimeOfDay;

                    if (currentTime >= earliestTime && currentTime <= latestTime)
                    {
                        await DoOpenWaterValve();
                    }
                }
                catch (Exception ex)
                {
                    CloseWaterValve();
                    _logger.LogError(ex.Message);
                }

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

    }
}