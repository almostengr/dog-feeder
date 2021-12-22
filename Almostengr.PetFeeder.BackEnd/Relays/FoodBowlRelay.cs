using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Enums;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.BackEnd.Constants;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class FoodBowlRelay : RelayBase, IFeedingRelay
    {
        private readonly ILogger<FoodBowlRelay> _logger;
        private readonly GpioController _gpio;

        public FoodBowlRelay(ILogger<FoodBowlRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPins(gpio, PinMode.Output, new Int32[] { GpioPin.FoodForwardRelay, GpioPin.FoodBackwardRelay });
        }

        private async Task RunMotor(MotorDirection direction, double onTime)
        {
            try
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.Off);
            _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.Off);
        }

        public async Task RunMotorBackwardAsync(double runTime)
        {
            await RunMotor(MotorDirection.Forward, runTime);
        }

        public async Task RunMotorForwardAsync(double runTime)
        {
            await RunMotor(MotorDirection.Backward, runTime);
        }
    }
}