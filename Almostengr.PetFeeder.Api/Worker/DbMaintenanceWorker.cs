using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class DbMaintenanceWorker : BaseWorker
    {
        private readonly ILogger<DbMaintenanceWorker> _logger;
        private readonly IFeedingRepository _feedingRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public DbMaintenanceWorker(ILogger<DbMaintenanceWorker> logger, IFeedingRepository feedingRepository,
            IScheduleRepository scheduleRepository) :
            base(logger)
        {
            _logger = logger;
            _feedingRepository = feedingRepository;
            _scheduleRepository = scheduleRepository;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(TimeSpan.FromMinutes(5));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Deleting old one time schedules");

                List<Schedule> schedules = await _scheduleRepository.GetOldOneTimeSchedulesAsync();
                foreach (var schedule in schedules)
                {
                    _scheduleRepository.DeleteSchedule(schedule);
                }

                await _scheduleRepository.SaveChangesAsync();

                _logger.LogInformation("Deleting old feedings");

                List<Feeding> feedings = await _feedingRepository.FindOldFeedings();
                foreach (var feeding in feedings)
                {
                    _feedingRepository.DeleteFeeding(feeding);
                }
                await _feedingRepository.SaveChangesAsync();

                await Task.Delay(TimeSpan.FromDays(1));
            }
        }
    }
}