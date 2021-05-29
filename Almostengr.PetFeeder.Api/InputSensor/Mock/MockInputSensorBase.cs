using System;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class MockInputSensorBase : IInputSensorBase
    {
        private readonly ILogger<MockInputSensorBase> _logger;
        internal readonly Random _random;

        public MockInputSensorBase(ILogger<MockInputSensorBase> logger)
        {
            _logger = logger;
            _random = new Random();
        }

        public Alarm AlarmTriggered(string type, string message)
        {
            _logger.LogInformation("Posting alarm");

            Alarm alarm = new Alarm();
            alarm.Id = _random.Next(1, 100000);
            alarm.Created = DateTime.Now;
            alarm.Message = _random.Next(1000000, 9999999).ToString();
            
            return alarm;
        }

        public bool IsWaterLevelLow(int vccPinNumber, int gndPinNumber)
        {
            return _random.Next(0, 10) > 5 ? true : false;
        }
    }
}