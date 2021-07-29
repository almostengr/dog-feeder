namespace Almostengr.PetFeeder.Web.InputSensor
{
    public interface IFoodStorageInputSensor : IInputSensorBase
    {
        bool IsFoodStorageLevelLow();
    }
}