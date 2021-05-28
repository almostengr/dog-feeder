using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class MockInputSensorBase : IInputSensorBase
    {
        private readonly ILogger<MockInputSensorBase> _logger;

        public MockInputSensorBase(ILogger<MockInputSensorBase> logger)
        {
            _logger = logger;
        }
        
        public Alarm AlarmTriggered(string type, string message)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWaterLevelLow(int vccPinNumber, int gndPinNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}