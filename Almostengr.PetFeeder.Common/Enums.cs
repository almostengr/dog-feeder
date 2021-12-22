namespace Almostengr.PetFeeder.Common.Enum
{
    public enum SettingName
    {
        FeedingMode,
        WateringMode,
        NightModeStartTime,
        NightModeEndTime,
    }

    public enum WateringMode
    {
        Off,
        Auto
    }

    public enum FeedingMode
    {
        Manual,
        Auto
    }
    
    public enum FeedingFrequency
    {
        Once = 1,
        Daily = 2
    }
}
