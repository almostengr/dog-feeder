namespace Almostengr.PetFeeder.BackEnd
{
    public class AppSettings
    {
        public string DatabaseFile { get; set; } = "PetFeeder.db";
        public OutputGpio OutputGpio { get; set; }
        public InputGpio InputGpio { get; set; }
    }

    public class InputGpio
    {
        public int PottyButton { get; set; } = 24;
    }

    public class OutputGpio
    {
        public int LightRelay { get; set; } = 23;
        public int FoodForwardRelay { get; set; } = 14;
        public int FoodBackwardRelay { get; set; } = 15;
        public int WaterValveRelay { get; set; } = 18;
    }
}