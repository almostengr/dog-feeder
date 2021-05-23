using System.Threading;
using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Api.Worker
{
    public interface IWaterStorageWorker
    {
        Task ShowWaterLevelMessageAsync(bool isWaterLevelLow);
        bool IsWaterLevelLow();
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}