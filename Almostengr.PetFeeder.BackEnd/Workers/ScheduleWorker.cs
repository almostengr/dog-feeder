using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Enums;
using Almostengr.PetFeeder.BackEnd.Services;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Workers
{
    public class ScheduleWorker : BaseWorker
    {
        private readonly IScheduleService _scheduleService;
        private readonly IFeedingService _feedingService;
        private readonly ISystemSettingService _systemSettingService;

        public ScheduleWorker(IServiceScopeFactory factory, ILogger<ScheduleWorker> logger)
        {
            _scheduleService = factory.CreateScope().ServiceProvider.GetRequiredService<IScheduleService>();
            _feedingService = factory.CreateScope().ServiceProvider.GetRequiredService<IFeedingService>();
            _systemSettingService = factory.CreateScope().ServiceProvider.GetRequiredService<ISystemSettingService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(stoppingToken.IsCancellationRequested == false)
            {
                bool schedulerActive = await _scheduleService.IsSchedulerActiveAsync();
                if (schedulerActive == false)
                {
                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                    continue;
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                List<ScheduleDto> schedules = await _scheduleService.GetSchedulesByTimeAsync(currentTime);

                foreach (ScheduleDto schedule in schedules)
                {
                    await FeedingTimeAsync(schedule);
                    
                    if (schedule.FeedingFrequency == FeedingFrequency.Once)
                    {
                        var d = Task.Run(() => _scheduleService.DeleteScheduleAsync(schedule.ScheduleId));
                    }
                }
            }
        }

        private async Task FeedingTimeAsync(ScheduleDto schedule)
        {
            SystemSettingDto feedingMode = await _systemSettingService.GetSystemSettingAsync(nameof(FeedingMode));

            if (schedule != null && feedingMode.Value == FeedingMode.Auto.ToString())
            {
                FeedingDto feedingDto = new FeedingDto()
                {
                    Amount = schedule.FeedingAmount,
                    FeedingType = FeedingType.Scheduled
                };

                Task createFeeding = Task.Run(() => _feedingService.CreateFeedingAsync(feedingDto));
            }
        }

    }
}