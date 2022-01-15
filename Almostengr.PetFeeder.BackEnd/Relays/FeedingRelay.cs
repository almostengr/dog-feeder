using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Enums;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.BackEnd.Constants;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class FeedingRelay : RelayBase, IFeedingRelay
    {
        private readonly ILogger<FeedingRelay> _logger;
        private readonly GpioController _gpio;

        public FeedingRelay(ILogger<FeedingRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPins(gpio, PinMode.Output, new Int32[] { GpioPin.FoodForwardRelay, GpioPin.FoodBackwardRelay });
        }

        private async Task<bool> RunMotor(MotorDirection direction, double onTime)
        {
            bool success = false;

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
                success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.Off);
            _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.Off);

            return success;
        }

        public async Task<bool> FeedMeAsync(double runTime)
        {
            try
            {
                await RunMotor(MotorDirection.Forward, 0.5);
                await RunMotor(MotorDirection.Backward, 0.5);
                await RunMotor(MotorDirection.Forward, 0.5);
                await RunMotor(MotorDirection.Backward, 0.5);
                await RunMotor(MotorDirection.Forward, runTime);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

    }
}