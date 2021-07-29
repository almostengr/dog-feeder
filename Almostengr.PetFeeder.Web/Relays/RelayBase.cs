using System.Device.Gpio;

namespace Almostengr.PetFeeder.Web.Relays
{
    public abstract class RelayBase : IRelayBase
    {
        public void OpenPins(GpioController gpio, PinMode pinMode, int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                OpenPin(gpio, pinMode, pins[i]);
            }
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int pin)
        {
            gpio.OpenPin(pin, pinMode);
        }

        public void ClosePins(GpioController gpio, int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                ClosePin(gpio, pins[i]);
            }
        }

        public void ClosePin(GpioController gpio, int pin)
        {
            gpio.ClosePin(pin);
        }
    }
}