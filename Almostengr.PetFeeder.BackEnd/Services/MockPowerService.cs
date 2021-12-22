using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd
{
    public class MockPowerService : IPowerService
    {
        private readonly ILogger<MockPowerService> _logger;

        public MockPowerService(ILogger<MockPowerService> logger)
        {
            _logger = logger;
        }

        public void Reboot()
        {
            _logger.LogInformation("Reboot requested");
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        }

        public void Shutdown()
        {
            _logger.LogInformation("System shutdown requested");
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        }
    }
}