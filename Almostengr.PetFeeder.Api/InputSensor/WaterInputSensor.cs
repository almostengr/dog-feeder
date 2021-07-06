using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class WaterSignalInput : InputSensorBase, IWaterInputSensor
    {

        public WaterSignalInput(ILogger<InputSensorBase> logger, GpioController gpio) : base(logger, gpio)
        {
        }

        public bool IsWaterBowlLow()
        {
            return base.IsWaterLevelLow(WaterBowlVcc, WaterBowlGnd);
        }
    }
}