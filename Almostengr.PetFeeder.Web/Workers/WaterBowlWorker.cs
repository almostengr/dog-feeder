using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Monitor.Workers
{
    public class WaterBowlWorker : BaseWorker, IWaterBowlWorker
    {
        private readonly ILogger<WaterBowlWorker> _logger;
        private readonly IWateringClient _wateringClient;
        private readonly IAlarmClient _alarmClient;

        public WaterBowlWorker(ILogger<WaterBowlWorker> logger, 
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
                        WateringDto watering = new WateringDto();
                        watering.Created = DateTime.Now;
                        await _wateringClient.CreateWateringAsync(watering);

                        var isWaterStillLow = await _wateringClient.GetWaterBowlStatus();

                        if (isWaterStillLow == true)
                        {
                            AlarmDto alarm = new AlarmDto();
                            alarm.Type = nameof(WateringDto).ToString();
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