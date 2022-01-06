namespace Almostengr.PetFeeder.BackEnd.Enums
{
    public enum MotorDirection
    {
        Forward,
        Backward,
        Off
    }

    public enum FeedingType
    {
        Scheduled,
        Manual
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

    public enum ScheduleType
    {
        Feeding = 1,
        Lighting = 2
    }
}