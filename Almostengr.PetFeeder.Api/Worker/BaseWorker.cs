using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Api.Worker
{
    public abstract class BaseWorker : BackgroundService, IBaseWorker
    {
        private readonly ILogger<BaseWorker> _logger;
        internal Uri ApiUri = new Uri("https://localhost:5000");
        internal int MonitorWorkerDelayMins = 60;

        protected BaseWorker(ILogger<BaseWorker> logger)
        {
            _logger = logger;
        }


        public async Task PostAsync<Entity>(string route, Entity entity) where Entity : ModelBase
        {
            try
            {
                var jsonSerialized = JsonConvert.SerializeObject(entity);

                using (var stringContent = new StringContent(jsonSerialized, Encoding.ASCII, "application/json"))
                {
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = ApiUri;

                        HttpResponseMessage response = await httpClient.PostAsync(route, stringContent);

                        if (response.IsSuccessStatusCode)
                        {
                            Entity entityResponse = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
                            _logger.LogInformation(response.StatusCode.ToString());
                        }
                        else
                        {
                            _logger.LogError(response.StatusCode.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

    }
}