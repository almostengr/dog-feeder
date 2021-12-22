using System;
using System.Threading;
using System.Threading.Tasks;

namespace Almostengr.PetFeeder.BackEnd.Workers
{
    public class WateringWorker : BaseWorker
    {
        public WateringWorker()
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                // check water bowl level and nighttime window

                // if water bowl level is low and not night time, then fill water bowl 

                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }
        }
    }
}