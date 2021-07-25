namespace Almostengr.PetFeeder.Api.InputSensor
{
    public interface IInputSensorBase
    {
        bool IsWaterLevelLow(int vccPinNumber, int gndPinNumber);
    }
}
