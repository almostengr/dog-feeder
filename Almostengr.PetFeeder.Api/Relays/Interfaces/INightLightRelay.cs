using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Api.Relays
{
    public interface INightLightRelay : IRelayBase
    {
        Task NightLightOffAsync();
        Task NightLightOnAsync();
    }
}