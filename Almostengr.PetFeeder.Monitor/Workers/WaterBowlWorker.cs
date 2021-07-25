using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Monitor.Workers
{
    public class WaterBowlWorker : BaseWorker, IWaterBowlWorker
    {
        private readonly ILogger<WaterBowlWorker> _logger;
        private readonly IWateringClient _wateringClient;
        private readonly IAlarmClient _alarmClient;

        public WaterBowlWorker(ILogger<WaterBowlWorker> logger, IWateringRepository repository,
            IWateringClient wateringClient, IAlarmClient alarmClient
            ) : base(logger)
        {
            _logger = logger;
            _wateringClient = wateringClient;
            _alarmClient = alarmClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TimeSpan earliestTime = new TimeSpan(06, 00, 00);
            TimeSpan latestTime = new TimeSpan(19, 00, 00);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                    bool? isWaterLow = await _wateringClient.GetWaterBowlStatus();

                    if (currentTime >= earliestTime && currentTime <= latestTime && isWaterLow == true)
                    {
                        Watering watering = new Watering();
                        watering.Timestamp = DateTime.Now;
                        await _wateringClient.CreateWateringAsync(watering);

                        var isWaterStillLow = await _wateringClient.GetWaterBowlStatus();

                        if (isWaterStillLow == true)
                        {
                            Alarm alarm = new Alarm();
                            alarm.Type = nameof(Watering).ToString();
                            alarm.Message = "Water level is low. Please refill";

                            await _alarmClient.CreateAlarmAsync(alarm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

                await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            }
        }

    }
}