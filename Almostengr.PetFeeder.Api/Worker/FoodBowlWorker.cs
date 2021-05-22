using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class FoodBowlWorker : BaseWorker, IFoodBowlWorker
    {
        private readonly ILogger<FoodBowlWorker> _logger;
        private readonly IFeedingRepository _feedingRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public FoodBowlWorker(ILogger<FoodBowlWorker> logger, IFeedingRepository feedingRepository,
            IScheduleRepository scheduleRepository)
            : base(logger)
        {
            _logger = logger;
            _feedingRepository = feedingRepository;
            _scheduleRepository = scheduleRepository;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting food bowl worker");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping food bowl worker");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Refreshing schedule information");
                    List<Schedule> schedules = await _scheduleRepository.GetAllActiveSchedulesAsync();

                    Schedule schedule = IsTimeToFeed(schedules);

                    if (schedule != null)
                    {
                        await PerformFeeding(schedule);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                // await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        public Schedule IsTimeToFeed(List<Schedule> schedules)
        {
            DateTime currentTime = DateTime.Now;

            foreach (var schedule in schedules)
            {
                bool frequencyMatch = DoesScheduleFrequencyMatchDayOfWeek(schedule.Frequency);
                if (schedule.ScheduledTime.Hour == currentTime.Hour &&
                    schedule.ScheduledTime.Minute == currentTime.Minute && frequencyMatch)
                {
                    return schedule;
                }
            }

            return null;
        }

        public bool DoesScheduleFrequencyMatchDayOfWeek(DayFrequency frequency)
        {
            bool value = false;
            DateTime dateTime = DateTime.Now;

            switch (frequency)
            {
                case DayFrequency.Once:
                    value = true;
                    break;

                case DayFrequency.Daily:
                    value = true;
                    break;

                case DayFrequency.Weekday:
                    switch (dateTime.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                        case DayOfWeek.Tuesday:
                        case DayOfWeek.Wednesday:
                        case DayOfWeek.Thursday:
                        case DayOfWeek.Friday:
                            value = true;
                            break;

                        default:
                            value = false;
                            break;
                    }
                    break;

                case DayFrequency.Weekend:
                    switch (dateTime.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                        case DayOfWeek.Saturday:
                            value = true;
                            break;

                        default:
                            value = false;
                            break;
                    }
                    break;

                default:
                    value = false;
                    break;
            }

            return value;
        }

        public async Task PerformFeeding(Schedule schedule)
        {
            Feeding feeding = new Feeding();
            feeding.Timestamp = DateTime.Now;
            feeding.Amount = schedule.FeedingAmount;
            feeding.ScheduleId = schedule.Id;

            // run the motor to dispense food

            await Task.Delay(TimeSpan.FromSeconds(feeding.Amount));

            // turn off motor

            await _feedingRepository.CreateFeedingAsync(feeding);
            await _feedingRepository.SaveChangesAsync();
        }

    }
}