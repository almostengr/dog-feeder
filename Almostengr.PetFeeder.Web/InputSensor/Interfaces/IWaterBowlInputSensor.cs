namespace Almostengr.PetFeeder.Web.InputSensor
{
    public interface IWaterBowlInputSensor : IInputSensorBase
    {
        bool IsWaterBowlLow();
    }
}