using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;

namespace Almostengr.PetFeeder.Web.Relays
{
    public interface IFoodBowlRelay : IRelayBase
    {
        Task<Feeding> PerformFeeding(Feeding feeding);
    }
}