namespace Almostengr.PetFeeder.Api.InputSensor
{
    public interface IFoodStorageInputSensor : IInputSensorBase
    {
        // double GetDistance();
        bool IsFoodStorageLevelLow();
    }
}