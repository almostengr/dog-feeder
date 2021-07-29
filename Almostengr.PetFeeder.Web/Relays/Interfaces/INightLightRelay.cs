using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Web.Relays
{
    public interface INightLightRelay : IRelayBase
    {
        Task NightLightOffAsync();
        Task NightLightOnAsync();
    }
}