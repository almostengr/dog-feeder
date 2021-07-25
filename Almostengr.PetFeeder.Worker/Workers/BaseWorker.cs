using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Worker.Workers
{
    public abstract class BaseWorker : BackgroundService, IBaseWorker
    {
        internal readonly int MonitorWorkerDelayMins = 60;

        protected BaseWorker(ILogger<BaseWorker> logger)
        {
        }

    }
}