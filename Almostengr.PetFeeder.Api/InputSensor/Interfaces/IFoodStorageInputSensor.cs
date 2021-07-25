namespace Almostengr.PetFeeder.Api.InputSensor
{
    public interface IFoodStorageInputSensor : IInputSensorBase
    {
        bool IsFoodStorageLevelLow();
    }
}