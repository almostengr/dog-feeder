using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Worker.Workers
{
    public abstract class BaseWorker : BackgroundService, IBaseWorker
    {
        private readonly ILogger<BaseWorker> _logger;
        // internal Uri ApiUri = new Uri("https://localhost:5000");
        HttpClient _httpClient;
        internal int MonitorWorkerDelayMins = 60;

        protected BaseWorker(ILogger<BaseWorker> logger)
        {
        }

    }
}