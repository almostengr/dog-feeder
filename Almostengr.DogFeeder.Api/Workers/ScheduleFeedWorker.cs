using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Data;
using Almostengr.DogFeeder.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Api.Worker
{
    public class ScheduleFeedWorker : BackgroundService
    {
        private readonly ILogger<ScheduleFeedWorker> _logger;
        private readonly IScheduleRepository _schedule;
        private readonly IFeedingRepository _feeding;

        public ScheduleFeedWorker(ILogger<ScheduleFeedWorker> logger, IScheduleRepository schedule, IFeedingRepository feeding)
        {
            _logger = logger;
            _schedule = schedule;
            _feeding = feeding;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting worker");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping worker");

            return base.StopAsync(cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            List<Schedule> schedules = await GetSchedule(true);

            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime currentTime = DateTime.Now;

                if (currentTime.Minute % 5 == 0)
                {
                    schedules = await GetSchedule(false);
                }

                foreach (var schedule in schedules)
                {
                    if (schedule.ScheduledTime.Hour == currentTime.Hour &&
                        schedule.ScheduledTime.Minute == currentTime.Minute)
                    {
                        // perform the feeding
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(60));
            }
        }

        private async Task<List<Schedule>> GetSchedule(bool firstRun)
        {
            _logger.LogInformation("Refreshing schdule information");
            return await _schedule.GetAllSchedulesAsync();
        }

    }
}