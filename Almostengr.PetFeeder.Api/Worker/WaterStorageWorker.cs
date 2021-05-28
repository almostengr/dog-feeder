// using System;
// using System.Device.Gpio;
// using System.Threading;
// using System.Threading.Tasks;
// using Almostengr.PetFeeder.Api.Models;
// using Almostengr.PetFeeder.Api.Repository;
// using Microsoft.Extensions.Logging;

// namespace Almostengr.PetFeeder.Api.Worker
// {
//     public class WaterStorageWorker : BaseWorker, IWaterStorageWorker
//     {
//         private readonly GpioController _gpio;
//         private readonly ILogger<WaterStorageWorker> _logger;
//         private readonly IAlarmRepository _alarmRepo;
        
//         private const int WaterVcc = 4;
//         private const int WaterGnd = 5;

//         public WaterStorageWorker(ILogger<WaterStorageWorker> logger, GpioController gpio, 
//             IAlarmRepository alarmRepo) : base(logger, gpio)
//         {
//             _gpio = gpio;
//             _logger = logger;
//             _alarmRepo = alarmRepo;
//         }

//         public override Task StartAsync(CancellationToken cancellationToken)
//         {
//             _gpio.OpenPin(WaterVcc, PinMode.Output);
//             _gpio.OpenPin(WaterGnd, PinMode.Input);

//             _gpio.Write(WaterVcc, GpioOff);

//             Task.Delay(TimeSpan.FromSeconds(1));

//             return base.StartAsync(cancellationToken);
//         }

//         public override Task StopAsync(CancellationToken cancellationToken)
//         {
//             _gpio.ClosePin(WaterVcc);
//             _gpio.ClosePin(WaterGnd);

//             return base.StopAsync(cancellationToken);
//         }

//         protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//         {
//             while (!stoppingToken.IsCancellationRequested)
//             {
//                 bool isWaterLevelLow = IsWaterLevelLow();

//                 await ShowWaterLevelMessageAsync(isWaterLevelLow);

//                 await Task.Delay(TimeSpan.FromMinutes(30));
//             }
//         }

//         public async Task ShowWaterLevelMessageAsync(bool isWaterLevelLow)
//         {
//             if (isWaterLevelLow)
//             {
//                 string message = "Water level is low. Please refill";
//                 Alarm alarm = AlarmTriggered(nameof(FoodStorageWorker), message);
//                 await _alarmRepo.CreateAlarmAsync(alarm);
//             }
//         }

//         public bool IsWaterLevelLow()
//         {
//             return base.IsWaterLevelLow(WaterVcc, WaterGnd);
//         }

//     }
// }