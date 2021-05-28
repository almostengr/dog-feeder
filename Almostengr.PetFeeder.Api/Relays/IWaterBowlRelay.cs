namespace Almostengr.PetFeeder.Api.Relays
{
    public interface IWaterBowlRelay : IRelayBase
    {
        void CloseWaterValve();
        void OpenWaterValve();
    }
}