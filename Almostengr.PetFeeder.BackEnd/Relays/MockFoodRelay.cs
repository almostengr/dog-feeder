using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class MockFoodBowlRelay : MockRelayBase, IFoodBowlRelay
    {
        public MockFoodBowlRelay(ILogger<MockFoodBowlRelay> logger) : base(logger)
        {
        }

        public async Task RunMotorBackwardAsync(double runTime)
        {
            await Task.Delay(TimeSpan.FromSeconds(runTime));
        }

        public async Task RunMotorForwardAsync(double runTime)
        {
            await Task.Delay(TimeSpan.FromSeconds(runTime));
        }
    }
}