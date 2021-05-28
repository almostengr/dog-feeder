using System.Device.Gpio;

namespace Almostengr.PetFeeder.Api.Constants
{
    public static class GpioPin
    {
        public readonly static PinValue On ;
        public readonly static PinValue Off ;

        static GpioPin(){
            On = PinValue.High;
            Off = PinValue.Low;
        }
    }
}