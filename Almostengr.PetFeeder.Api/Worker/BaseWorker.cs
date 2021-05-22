using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Worker
{
    public abstract class BaseWorker : BackgroundService
    {
        private readonly ILogger<BaseWorker> _logger;

        protected BaseWorker(ILogger<BaseWorker> logger)
        {
            _logger = logger;
        }
    }
}