using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class MockFoodStorageInputSensor : MockInputSensorBase, IFoodStorageInputSensor
    {
        public MockFoodStorageInputSensor(ILogger<MockInputSensorBase> logger) : base(logger)
        {
        }

        public bool IsFoodStorageLevelLow()
        {
            return _random.Next(0,10) > 8 ? true : false;
        }
    }
}