namespace Almostengr.PetFeeder.BackEnd
{
    public class AppSettings
    {
        public string DatabaseFile { get; set; } = "PetFeeder.db";
        public OutputGpio OutputGpio { get; set; }
    }

    public class OutputGpio
    {
        public int LightRelay { get; set; } = 23;
        public int FoodForwardRelay { get; set; } = 14;
        public int FoodBackwardRelay { get; set; } = 15;
        public int WaterValveRelay { get; set; } = 18;
    }
}