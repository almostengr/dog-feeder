using System.Threading.Tasks;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public interface IFeedingRelay : IRelayBase
    {
        Task<bool> FeedMeAsync(double runTime);
    }
}