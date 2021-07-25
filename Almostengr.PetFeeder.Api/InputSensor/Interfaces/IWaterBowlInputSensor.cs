namespace Almostengr.PetFeeder.Api.InputSensor
{
    public interface IWaterBowlInputSensor : IInputSensorBase
    {
        bool IsWaterBowlLow();
    }
}