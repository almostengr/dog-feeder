using System;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class MockWaterInputSensor : MockInputSensorBase, IWaterInputSensor
    {
        private readonly ILogger<MockWaterInputSensor> _logger;

        public MockWaterInputSensor(ILogger<MockWaterInputSensor> logger) : base(logger)
        {
            _logger = logger;
        }

        public bool IsWaterBowlLow()
        {
            return _random.Next(0,10) > 5 ? true : false;
        }
    }
}