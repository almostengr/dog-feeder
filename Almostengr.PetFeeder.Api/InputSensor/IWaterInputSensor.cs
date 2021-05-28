namespace Almostengr.PetFeeder.Api.InputSensor
{
    public interface IWaterInputSensor : IInputSensorBase
    {
        bool IsWaterBowlLow();
    }
}