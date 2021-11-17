using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Constants;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Almostengr.PetFeeder.BackEnd.Relays;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class WaterBowlRelay : RelayBase, IWaterBowlRelay
    {
        private readonly ILogger<WaterBowlRelay> _logger;
        private readonly GpioController _gpio;

        public WaterBowlRelay(ILogger<WaterBowlRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;
            
            OpenPin(gpio, PinMode.Output, GpioPin.WaterValveRelay);
        }

        public async Task<WateringDto> AddWaterBowlAsync()
        {
            // check water level 

            // if water level is low, turn on the relay

            // return amount of water added and current time

            return new WateringDto(); 
        }
    }
}