using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Relays;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Workers
{
    public class NightLightWorker : BaseWorker
    {
        private readonly TimeSpan nightTimeOn = new TimeSpan(19, 00, 00);
        private readonly TimeSpan nightTimeOff = new TimeSpan(07, 00, 00);
        private readonly INightLightRelay _nightLightRelay;
        private readonly ILogger<NightLightWorker> _logger;

        public NightLightWorker(ILogger<NightLightWorker> logger,
            INightLightRelay nightLightRelay) : base(logger)
        {
            _nightLightRelay = nightLightRelay;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                if (currentTime >= nightTimeOn || currentTime <= nightTimeOff)
                {
                    await _nightLightRelay.NightLightOnAsync();
                }
                else {
                    await _nightLightRelay.NightLightOffAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(15));
            }
        }

    }
}