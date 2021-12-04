namespace Almostengr.PetFeeder.BackEnd.Relays.Interfaces
{
    public interface IWaterLevelRelay : IRelayBase
    {
        void TurnOn();
        void TurnOff();
    }
}