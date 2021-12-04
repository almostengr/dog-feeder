using System.Device.Gpio;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class MockWaterLevelRelay : IWaterLevelRelay
    {
        public void ClosePin(GpioController gpio, int pin)
        {
            throw new System.NotImplementedException();
        }

        public void ClosePins(GpioController gpio, int[] pins)
        {
            throw new System.NotImplementedException();
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int pin)
        {
            throw new System.NotImplementedException();
        }

        public void OpenPins(GpioController gpio, PinMode pinMode, int[] pins)
        {
            throw new System.NotImplementedException();
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }

        public void TurnOn()
        {
            throw new System.NotImplementedException();
        }
    }
}