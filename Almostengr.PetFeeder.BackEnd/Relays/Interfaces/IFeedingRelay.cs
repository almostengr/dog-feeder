using System.Threading.Tasks;

namespace Almostengr.PetFeeder.BackEnd.Relays.Interfaces
{
    public interface IFeedingRelay : IRelayBase
    {
        Task<bool> FeedMeAsync(double runTime);
    }
}