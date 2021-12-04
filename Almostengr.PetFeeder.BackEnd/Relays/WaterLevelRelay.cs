using System.Device.Gpio;
using Almostengr.PetFeeder.BackEnd.Constants;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class WaterLevelRelay : RelayBase, IWaterLevelRelay
    {
        private readonly GpioController _gpio;

        public WaterLevelRelay(ILogger<WaterLevelRelay> logger, GpioController gpio) : base()
        {
            _gpio = gpio;
            
            OpenPin(gpio, PinMode.Output, GpioPin.WaterValveRelay);
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }

        public void TurnOn()
        {
            throw new System.NotImplementedException();
        }
    }
}