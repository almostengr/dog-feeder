using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.InputSensor;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class WaterStorageWorker : BaseWorker, IWaterStorageWorker
    {
        private readonly ILogger<WaterStorageWorker> _logger;
        private readonly IAlarmRepository _alarmRepo;
        private readonly IWaterInputSensor _sensor;

        public WaterStorageWorker(ILogger<WaterStorageWorker> logger, IAlarmRepository alarmRepo,
            IWaterInputSensor sensor) : base(logger)
        {
            _logger = logger;
            _alarmRepo = alarmRepo;
            _sensor = sensor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                bool activeWaterAlarms = await _alarmRepo.GetActiveAlarmsExistByTypeAsync(nameof(Feeding));

                bool waterLevelLow = _sensor.IsWaterBowlLow();

                if (waterLevelLow)
                {
                    Alarm alarm = new Alarm();
                    alarm.Type = nameof(Watering);
                    alarm.Message = "Water storage level is low. Please refill.";
                    
                    await _alarmRepo.CreateAsync(alarm);
                    await _alarmRepo.SaveChangesAsync();
                }

                if (activeWaterAlarms == true && waterLevelLow == false)
                {
                    var alarms = await _alarmRepo.GetActiveAlarmsByTypeAsync(nameof(Watering));
                    _alarmRepo.DismissAlarms(alarms);
                    await _alarmRepo.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(MonitorWorkerDelayMins), stoppingToken);
            }
        }

    }
}