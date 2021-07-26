using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Enums;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Monitor.Workers
{
    public class FoodBowlWorker : BaseWorker, IFoodBowlWorker
    {
        private readonly ILogger<FoodBowlWorker> _logger;
        private readonly IFeedingClient _feedingClient;
        private readonly IScheduleClient _scheduleClient;

        public FoodBowlWorker(ILogger<FoodBowlWorker> logger, IFeedingClient feedingClient,
            IScheduleClient scheduleClient) : base(logger)
        {
            _logger = logger;
            _feedingClient = feedingClient;
            _scheduleClient = scheduleClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    IList<ScheduleDto> schedules = await _scheduleClient.GetActiveSchedulesAsync();

                    ScheduleDto schedule = IsTimeToFeed(schedules);

                    if (schedule != null) // if time to feed, then call feeding api
                    {
                        await DoFeedPetAsync(schedule);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

                await Task.Delay(TimeSpan.FromSeconds(45), stoppingToken);
            }
        }

        public async Task DoFeedPetAsync(ScheduleDto schedule)
        {
            FeedingDto feeding = new FeedingDto();
            feeding.Amount = schedule.FeedingAmount;
            feeding.ScheduleId = schedule.ScheduleId;

            await _feedingClient.CreateFeedingAsync(feeding);
        }

        public ScheduleDto IsTimeToFeed(IList<ScheduleDto> schedules)
        {
            DateTime currentDateTime = DateTime.Now;
            currentDateTime = currentDateTime.AddMilliseconds(-currentDateTime.Millisecond)
                .AddSeconds(-currentDateTime.Second);
            TimeSpan currentTime = currentDateTime.TimeOfDay;

            foreach (var schedule in schedules)
            {
                bool doesFrequencyMatch = DoesScheduleFrequencyMatchDayOfWeek(schedule.Frequency);
                if (doesFrequencyMatch && currentTime == schedule.ScheduledTime.TimeOfDay)
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

    }
}