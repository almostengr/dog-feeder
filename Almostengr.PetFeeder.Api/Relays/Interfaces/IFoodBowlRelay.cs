using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Relays
{
    public interface IFoodBowlRelay : IRelayBase
    {
        Task<Feeding> PerformFeeding(Feeding feeding);
    }
}