using System.Threading;
using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Api.Worker
{
    public interface IFoodStorageWorker
    {
        void Dispose();
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}