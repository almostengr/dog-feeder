using System.Threading.Tasks;

namespace Almostengr.PetFeeder.BackEnd.Relays.Interfaces
{
    public interface INightLightRelay : IRelayBase
    {
        Task NightLightOffAsync();
        Task NightLightOnAsync();
    }
}