using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Worker.Workers
{
    public interface IWaterBowlWorker : IBaseWorker
    {
        Watering RefillWaterBowl();
    }
}