using System.Threading.Tasks;

namespace Almostengr.PetFeeder.BackEnd.Relays.Interfaces
{
    public interface IFoodBowlRelay : IRelayBase
    {
        Task RunMotorForwardAsync(double runTime);
        Task RunMotorBackwardAsync(double runTime);
    }
}