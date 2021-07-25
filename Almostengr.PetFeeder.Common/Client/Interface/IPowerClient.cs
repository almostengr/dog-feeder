using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IPowerClient
    {
        Task ShutDown();
        Task Restart();
    }
}