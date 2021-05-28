using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Worker
{
    public interface IWaterBowlWorker : IBaseWorker
    {
        Watering RefillWaterBowl();
    }
}