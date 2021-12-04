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
        public static readonly int LightRelay = 23;
        public static readonly int FoodForwardRelay = 14;
        public static readonly int FoodBackwardRelay = 15;
        public static readonly int WaterValveRelay = 18;
    }
}