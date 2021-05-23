using System;
using System.Collections.Generic;
using System.Device.Gpio;
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
        private readonly GpioController _gpio;

        private const int FoodForwardRelay = 14;
        private const int FoodBackwardRelay = 15;

        public FoodBowlWorker(ILogger<FoodBowlWorker> logger, IFeedingRepository feedingRepository,
            IScheduleRepository scheduleRepository, GpioController gpio)
            : base(logger, gpio)
        {
            _logger = logger;
            _feedingRepository = feedingRepository;
            _scheduleRepository = scheduleRepository;
            _gpio = gpio;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _gpio.OpenPin(FoodForwardRelay, PinMode.Output); // initialize GPIO pins
            _gpio.OpenPin(FoodBackwardRelay, PinMode.Output);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _gpio.ClosePin(FoodForwardRelay); // release GPIO pins
            _gpio.ClosePin(FoodBackwardRelay);
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
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, 0.5);
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, feeding.Amount);

            await _feedingRepository.CreateFeedingAsync(feeding);
            await _feedingRepository.SaveChangesAsync();
        }

        private async Task RunMotor(MotorDirection direction, double onTime)
        {
            switch (direction)
            {
                case MotorDirection.Forward:
                    _gpio.Write(FoodForwardRelay, GpioOn);
                    _gpio.Write(FoodBackwardRelay, GpioOff);
                    break;

                case MotorDirection.Backward:
                    _gpio.Write(FoodForwardRelay, GpioOff);
                    _gpio.Write(FoodBackwardRelay, GpioOn);
                    break;

                default:
                    break;
            }

            await Task.Delay(TimeSpan.FromSeconds(onTime));

            _gpio.Write(FoodForwardRelay, GpioOff);
            _gpio.Write(FoodBackwardRelay, GpioOff);
        }

    }
}