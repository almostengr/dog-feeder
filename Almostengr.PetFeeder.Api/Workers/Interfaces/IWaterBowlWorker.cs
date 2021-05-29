using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Workers
{
    public interface IWaterBowlWorker : IBaseWorker
    {
        Watering RefillWaterBowl();
    }
}