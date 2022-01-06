using System.Device.Gpio;

namespace Almostengr.PetFeeder.BackEnd.Constants
{

    public static class GpioOutput
    {
        public readonly static PinValue On;
        public readonly static PinValue Off;
    }

    public static class GpioPin
    {
        public const int LightRelay = 23;
        public const int FoodForwardRelay = 14;
        public const int FoodBackwardRelay = 15;
        public const int WaterValveRelay = 18;
    }

    public static class PowerAction
    {
        public const string Reboot = "reboot";
        public const string Shutdown = "shutdown";
    }

    public static class ErrorMessage
    {
        public static readonly string Api500 = "A problem occurred when handling your request";
    }

    public static class SettingName
    {
        public const string FeedingMode = "FeedingMode";
        public const string WateringMode = "WateringMode";
    }

}