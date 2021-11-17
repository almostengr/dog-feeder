using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Relays.Interfaces
{
    public interface IFoodBowlRelay : IRelayBase
    {
        Task<FeedingDto> PerformFeeding(FeedingDto feeding);
    }
}