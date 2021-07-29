namespace Almostengr.PetFeeder.Web.InputSensor
{
    public interface IInputSensorBase
    {
        bool IsWaterLevelLow(int vccPinNumber, int gndPinNumber);
    }
}
