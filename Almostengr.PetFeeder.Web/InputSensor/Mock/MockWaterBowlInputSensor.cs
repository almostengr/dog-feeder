using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.InputSensor
{
    public class MockWaterBowlInputSensor : MockInputSensorBase, IWaterBowlInputSensor
    {
        private readonly ILogger<MockWaterBowlInputSensor> _logger;

        public MockWaterBowlInputSensor(ILogger<MockWaterBowlInputSensor> logger) : base(logger)
        {
            _logger = logger;
        }

        public bool IsWaterBowlLow()
        {
            return _random.Next(0,10) > 5 ? true : false;
        }
    }
}