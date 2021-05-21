using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class WaterBowlWorker : BaseWorker
    {
        private readonly ILogger<WaterBowlWorker> _logger;
        public WaterBowlWorker(ILogger<WaterBowlWorker> logger) : base(logger)
        {
            _logger = logger;
        }

        public override void Dispose()
        {
            base.Dispose();
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
                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                if (currentTime >= earliestTime && currentTime <= latestTime)
                {
                    // check water level 

                    // if water level low, then refill
                }

                await Task.Delay(TimeSpan.FromHours(1));
            }
        }

        private async Task<bool> IsWaterBowlFull()
        {
            // check if GPIO has continunity

            return true;
        }

        private async Task DoRefillWaterBowl(bool doRefill)
        {
            try
            {
                bool isWaterLow = false;
                isWaterLow = await IsWaterBowlFull();

                while (isWaterLow)
                {
                    // open water valve
                }

                CloseWaterValve();
            }
            catch (Exception ex)
            {
                CloseWaterValve();
                _logger.LogError(ex.Message);
            }

            return;
        }

        private async Task CloseWaterValve()
        {
            // turn off water
        }

    }
}