using System.Device.Gpio;
using Almostengr.PetFeeder.Web.Constants;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Relays
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

        public void OpenWaterValve()
        {
            _logger.LogInformation("Turning on water");
            _gpio.Write(GpioPin.WaterValveRelay, GpioOutput.On);
        }

        public void CloseWaterValve()
        {
            _logger.LogInformation("Turning off water");
            _gpio.Write(GpioPin.WaterValveRelay, GpioOutput.Off); // turn off water
        }

    }
}