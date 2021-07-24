using System.Device.Gpio;

namespace Almostengr.PetFeeder.Api.Relays
{
    public abstract class RelayBase : IRelayBase
    {
        internal const int LightRelay = 23;
        internal const int FoodForwardRelay = 14;
        internal const int FoodBackwardRelay = 15;
        internal const int WaterValveRelay = 18;


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