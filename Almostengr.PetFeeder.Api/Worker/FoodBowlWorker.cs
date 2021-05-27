using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class FoodBowlWorker : BaseWorker, IFoodBowlWorker
    {
        private readonly ILogger<FoodBowlWorker> _logger;
        private readonly IFeedingRepository _feedingRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IAlarmRepository _alarmRepository;
        private readonly GpioController _gpio;


        public FoodBowlWorker(ILogger<FoodBowlWorker> logger, IFeedingRepository feedingRepository,
            IScheduleRepository scheduleRepository, IAlarmRepository alarmRepository, GpioController gpio)
            : base(logger, gpio)
        {
            _logger = logger;
            _feedingRepository = feedingRepository;
            _scheduleRepository = scheduleRepository;
            _alarmRepository = alarmRepository;
            _gpio = gpio;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            // _gpio.OpenPin(FoodForwardRelay, PinMode.Output); // initialize GPIO pins
            // _gpio.OpenPin(FoodBackwardRelay, PinMode.Output);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            // _gpio.ClosePin(FoodForwardRelay); // release GPIO pins
            // _gpio.ClosePin(FoodBackwardRelay);
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

                    // bool doAlarmsExist = await _alarmRepository.GetActiveAlarmsExistByTypeAsync(nameof(FoodStorageWorker));

                    // if (schedule != null && doAlarmsExist == false)
                    // {
                    //     await PerformFeeding(schedule);
                    // }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
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
                    // return schedule;


                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = ApiUri;

                        Feeding feeding = new Feeding();
                        feeding.Amount = schedule.FeedingAmount;
                        feeding.ScheduleId = schedule.Id;
                        feeding.Timestamp = DateTime.Now;

                        HttpResponseMessage response = httpClient.PostAsync("/feedings", feeding);

                        // if (response.IsSuccessStatusCode)
                        // {
                        //     schedules = JsonConvert.DeserializeObject<List<>>(response.Content.ReadAsStringAsync().Result);
                        // }
                        // else
                        // {
                        //     schedules = new List<ScheduleViewModel>();
                        // }
                    }
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


    }
}