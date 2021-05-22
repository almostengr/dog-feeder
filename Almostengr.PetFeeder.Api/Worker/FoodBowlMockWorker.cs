using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class FoodBowlMockWorker : BaseWorker, IFoodBowlWorker
    {
        private readonly ILogger<FoodBowlMockWorker> _logger;
        private Random _random;

        public FoodBowlMockWorker(ILogger<FoodBowlMockWorker> logger) : base(logger)
        {
            _logger = logger;
            _random = new Random();
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

        public async Task PerformFeeding(Schedule schedule)
        {
            _logger.LogInformation("Dispensing food");
            await Task.Delay(TimeSpan.FromSeconds(schedule.FeedingAmount));
        }

        private string MockIpAddress()
        {
            string ipAddress = string.Empty;

            for (int i = 0; i < 4; i++)
            {
                ipAddress += _random.Next(0, 254) + ".";
            }

            ipAddress = ipAddress.Substring(ipAddress.Length - 1);

            return ipAddress;
        }

        private Schedule CreateRandomSchedule()
        {
            Schedule schedule = new Schedule();
            schedule.FeedingAmount = _random.NextDouble() * 3;
            schedule.Frequency = DayFrequency.Daily;
            schedule.Id = _random.Next(0, 555);
            schedule.IpAddress = MockIpAddress();
            schedule.IsActive = (_random.Next(0, 5) > 2);
            schedule.ScheduledTime = DateTime.Now.AddDays(_random.Next(2, 365));

            return schedule;
        }

        public List<Schedule> GetAllActiveSchedulesAsync()
        {
            int count = _random.Next(1, 15);
            List<Schedule> schedules = null;

            for (int i = 0; i < count; i++)
            {
                Schedule schedule = CreateRandomSchedule();
                schedules.Add(schedule);
            }

            Schedule schedule1 = new Schedule();
            schedule1.FeedingAmount = _random.NextDouble() * 3;
            schedule1.Frequency = DayFrequency.Daily;
            schedule1.Id = _random.Next(0, 555);
            schedule1.IpAddress = MockIpAddress();
            schedule1.IsActive = true;
            schedule1.ScheduledTime = DateTime.Now.AddMinutes(2);
            schedules.Add(schedule1);

            return schedules;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Refreshing schedule information");
                    List<Schedule> schedules = GetAllActiveSchedulesAsync();

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

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

    }
}