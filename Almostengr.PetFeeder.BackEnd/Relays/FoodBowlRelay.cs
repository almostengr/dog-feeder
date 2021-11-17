using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Enums;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.BackEnd.Constants;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class FoodBowlRelay : RelayBase, IFoodBowlRelay
    {
        private readonly ILogger<FoodBowlRelay> _logger;
        private readonly GpioController _gpio;
        
        public FoodBowlRelay(ILogger<FoodBowlRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPins(gpio, PinMode.Output, new Int32[] { GpioPin.FoodForwardRelay, GpioPin.FoodBackwardRelay });
        }

        public async Task<FeedingDto> PerformFeeding(FeedingDto feedingDto)
        {
            // run the motor to dispense food
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, 0.5);
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, feedingDto.Amount);
            await RunMotor(MotorDirection.Backward, 0.5);

            feedingDto.Created = DateTime.Now;

            return feedingDto;
        }

        private async Task RunMotor(MotorDirection direction, double onTime)
        {
            switch (direction)
            {
                case MotorDirection.Forward:
                    _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.On);
                    _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.Off);
                    break;

                case MotorDirection.Backward:
                    _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.Off);
                    _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.On);
                    break;

                default:
                    _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.Off);
                    _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.Off);
                    break;
            }

            await Task.Delay(TimeSpan.FromSeconds(onTime));

            _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.Off);
            _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.Off);
        }
    }
}