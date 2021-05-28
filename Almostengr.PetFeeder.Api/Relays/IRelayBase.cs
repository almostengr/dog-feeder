using System.Device.Gpio;

namespace Almostengr.PetFeeder.Api.Relays
{
    public interface IRelayBase
    {
        void OpenPins(GpioController gpio, PinMode pinMode, int[] pins);
        void ClosePins(GpioController gpio, int[] pins);
    }
}