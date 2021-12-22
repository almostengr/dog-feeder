using System.Device.Gpio;

namespace Almostengr.PetFeeder.BackEnd.Constants
{

    public static class GpioOutput
    {
        public readonly static PinValue On ;
        public readonly static PinValue Off ;
    }

    public static class GpioPin
    {
        public const int LightRelay = 23;
        public const int FoodForwardRelay = 14;
        public const int FoodBackwardRelay = 15;
        public const int WaterValveRelay = 18;
    }

}