using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class MockWaterStorageInputSensor : MockInputSensorBase, IWaterStorageInputSensor
    {
        public MockWaterStorageInputSensor(ILogger<MockInputSensorBase> logger) : base(logger)
        {
        }

        public bool IsWaterStorageLow()
        {
            return _random.Next(0,10) > 8 ? true : false;
        }
    }
}