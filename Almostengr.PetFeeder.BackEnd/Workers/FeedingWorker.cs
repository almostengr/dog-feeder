using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Common.Enum;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Workers
{
    public class FeedingWorker : BaseWorker
    {
        private readonly IFeedingService _feedingService;
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<FeedingWorker> _logger;
        private readonly ISystemSettingService _systemSettingService;

        public FeedingWorker(ILogger<FeedingWorker> logger,
            IScheduleService scheduleService,
            ISystemSettingService systemSettingService,
            IFeedingService feedingService) : base()
        {
            _feedingService = feedingService;
            _scheduleService = scheduleService;
            _logger = logger;
            _systemSettingService = systemSettingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

                var feedingMode = await _systemSettingService.GetSystemSettingAsync(nameof(FeedingMode));

                if (feedingMode.Value == FeedingMode.Manual.ToString())
                {
                    continue;
                }

                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                // check if current time matches scheduled feeding time 
                var schedules = await _scheduleService.GetSchedulesByTimeAsync(currentTime);

                // if so, feed the pet
                if (schedules.Count > 0)
                {
                    FeedingDto feedingDto = new FeedingDto()
                    {
                        Amount = schedules[0].FeedingAmount,
                        ScheduledFeeding = true
                    };

                    await _feedingService.PerformFeedingAsync(feedingDto);

                    foreach (var schedule in schedules)
                    {
                        if (schedule.FeedingFrequency == FeedingFrequency.Once)
                        {
                            await _scheduleService.DeleteScheduleAsync(schedule.ScheduleId);
                        }
                    }
                }
            }
        } // end ExecuteAsync

    }
}