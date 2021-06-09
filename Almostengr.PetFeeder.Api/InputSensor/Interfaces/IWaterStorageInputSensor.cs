namespace Almostengr.PetFeeder.Api.InputSensor
{
    public interface IWaterStorageInputSensor : IInputSensorBase
    {
        bool IsWaterStorageLow();
    }
}