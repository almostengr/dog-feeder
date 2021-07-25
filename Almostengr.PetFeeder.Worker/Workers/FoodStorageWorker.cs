using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.InputSensor;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Worker.Workers
{
    public class FoodStorageWorker : BaseWorker, IFoodStorageWorker
    {
        private readonly ILogger<FoodStorageWorker> _logger;
        private readonly IAlarmRepository _alarmRepo;
        private readonly IFoodStorageInputSensor _sensor;

        public FoodStorageWorker(ILogger<FoodStorageWorker> logger, IAlarmRepository alarmRepo, 
            IFoodStorageInputSensor sensor) : base(logger)
        {
            _logger = logger;
            _alarmRepo = alarmRepo;
            _sensor = sensor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                bool activeFoodAlarms = await _alarmRepo.GetActiveAlarmsExistByTypeAsync(nameof(Feeding));

                bool foodLevelLow = _sensor.IsFoodStorageLevelLow();

                if (foodLevelLow)
                {
                    Alarm alarm = new Alarm();
                    alarm.Type = nameof(Feeding).ToString();
                    alarm.Message = "Food storage is low. Please refill.";

                    await _alarmRepo.CreateAsync(alarm);
                    await _alarmRepo.SaveChangesAsync();
                }

                if (activeFoodAlarms == true && foodLevelLow == false)
                {
                    var alarms = await _alarmRepo.GetActiveAlarmsByTypeAsync(nameof(Feeding));
                    _alarmRepo.DismissAlarms(alarms);
                    await _alarmRepo.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(MonitorWorkerDelayMins), stoppingToken);
            }
        }

    }
}