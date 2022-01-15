using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Relays;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class MockFeedingRelay : IFeedingRelay
    {
        private readonly ILogger<MockFeedingRelay> _logger;

        public MockFeedingRelay(ILogger<MockFeedingRelay> logger)
        {
            _logger = logger;
        }

        public void ClosePin(GpioController gpio, int pin)
        {
            throw new System.NotImplementedException();
        }

        public void ClosePins(GpioController gpio, int[] pins)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> FeedMeAsync(double runTime)
        {
            _logger.LogDebug("Performing feeding");
            await Task.Delay(TimeSpan.FromSeconds(runTime));
            return true;
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int pin)
        {
            throw new System.NotImplementedException();
        }

        public void OpenPins(GpioController gpio, PinMode pinMode, int[] pins)
        {
            throw new System.NotImplementedException();
        }

    }
}