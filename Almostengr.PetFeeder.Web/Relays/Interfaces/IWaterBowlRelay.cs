namespace Almostengr.PetFeeder.Web.Relays
{
    public interface IWaterBowlRelay : IRelayBase
    {
        void CloseWaterValve();
        void OpenWaterValve();
    }
}