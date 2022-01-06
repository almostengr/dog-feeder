using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Enums;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
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
        private readonly ILogger<ScheduleWorker> _logger;

        public ScheduleWorker(IServiceScopeFactory factory, ILogger<ScheduleWorker> logger)
        {
            _scheduleService = factory.CreateScope().ServiceProvider.GetRequiredService<IScheduleService>();
            _feedingService = factory.CreateScope().ServiceProvider.GetRequiredService<IFeedingService>();
            _systemSettingService = factory.CreateScope().ServiceProvider.GetRequiredService<ISystemSettingService>();
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(stoppingToken.IsCancellationRequested == false)
            {
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                // check if current time matches scheduled feeding time 
                var schedules = await _scheduleService.GetSchedulesByTimeAsync(currentTime);

                
                foreach (var schedule in schedules)
                {
                    if (schedule.FeedingFrequency == FeedingFrequency.Once)
                    {
                        await _scheduleService.DeleteScheduleAsync(schedule.ScheduleId);
                    }
                }
            }
        }
        

        private async Task FeedingTimeAsync(List<ScheduleDto> schedules)
        {
            var feedingMode = await _systemSettingService.GetSystemSettingAsync(nameof(FeedingMode));

            if (schedules.Count > 0 && feedingMode.Value == FeedingMode.Auto.ToString())
            {
                FeedingDto feedingDto = new FeedingDto()
                {
                    Amount = schedules[0].FeedingAmount,
                    FeedingType = FeedingType.Scheduled
                };

                _feedingService.CreateFeedingAsync(feedingDto);
            }
        }


    }
}