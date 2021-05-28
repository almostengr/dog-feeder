using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Api.Constants;

namespace Almostengr.PetFeeder.Api.Relays
{

    public class FoodBowlRelay : RelayBase, IFoodBowlRelay
    {
        private readonly ILogger<FoodBowlRelay> _logger;
        private readonly GpioController _gpio;
        private const int FoodForwardRelay = 14;
        private const int FoodBackwardRelay = 15;

        public FoodBowlRelay(ILogger<FoodBowlRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPins(gpio, PinMode.Output, new Int32[] { FoodForwardRelay, FoodBackwardRelay });
        }

        public async Task<Feeding> PerformFeeding(Feeding feeding)
        {
            // run the motor to dispense food
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, 0.5);
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, feeding.Amount);
            await RunMotor(MotorDirection.Backward, 0.5);

            feeding.Timestamp = DateTime.Now;

            return feeding;
        }

        private async Task RunMotor(MotorDirection direction, double onTime)
        {
            switch (direction)
            {
                case MotorDirection.Forward:
                    _gpio.Write(FoodForwardRelay, GpioOutput.On);
                    _gpio.Write(FoodBackwardRelay, GpioOutput.Off);
                    break;

                case MotorDirection.Backward:
                    _gpio.Write(FoodForwardRelay, GpioOutput.Off);
                    _gpio.Write(FoodBackwardRelay, GpioOutput.On);
                    break;

                default:
                    break;
            }

            await Task.Delay(TimeSpan.FromSeconds(onTime));

            _gpio.Write(FoodForwardRelay, GpioOutput.Off);
            _gpio.Write(FoodBackwardRelay, GpioOutput.Off);
        }
    }
}
