using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public interface IInputSensorBase
    {
        Alarm AlarmTriggered(string type, string message);
        bool IsWaterLevelLow(int vccPinNumber, int gndPinNumber);
    }
}
