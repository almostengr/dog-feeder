using System.Device.Gpio;

namespace Almostengr.PetFeeder.Common.Constants
{
    public static class GpioOutput
    {
        public readonly static PinValue On ;
        public readonly static PinValue Off ;

        static GpioOutput(){
            On = PinValue.High;
            Off = PinValue.Low;
        }
    }
}