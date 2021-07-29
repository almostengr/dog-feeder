using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.InputSensor
{
    public class WaterBowlInputSensor : InputSensorBase, IWaterBowlInputSensor
    {
        private const int WaterBowlVcc = 4;
        private const int WaterBowlGnd = 5;

        public WaterBowlInputSensor(ILogger<InputSensorBase> logger, GpioController gpio) : base(logger, gpio)
        {
        }

        public bool IsWaterBowlLow()
        {
            return base.IsWaterLevelLow(WaterBowlVcc, WaterBowlGnd);
        }
    }
}