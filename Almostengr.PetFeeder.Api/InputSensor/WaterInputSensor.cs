using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class WaterSignalInput : InputSensorBase, IWaterInputSensor
    {
        private const int WaterBowlVcc = 20;
        private const int WaterBowlGnd = 21;

        public WaterSignalInput(ILogger<InputSensorBase> logger, GpioController gpio) : base(logger, gpio)
        {
        }

        public bool IsWaterBowlLow()
        {
            return base.IsWaterLevelLow(WaterBowlVcc, WaterBowlGnd);
        }
    }
}