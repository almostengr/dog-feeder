using System.Device.Gpio;

namespace Almostengr.PetFeeder.Api.Relays
{
    public interface IRelayBase
    {
        void OpenPins(GpioController gpio, PinMode pinMode, int[] pins);
        void OpenPin(GpioController gpio, PinMode pinMode, int pin);
        void ClosePins(GpioController gpio, int[] pins);
        void ClosePin(GpioController gpio, int pin);
    }
}