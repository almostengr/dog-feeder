using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        private readonly AppSettings _appSettings;
        public Uri BackEndUrl;

        public BaseController(ILogger<BaseController> logger, AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<T> GetAsync<T>(string route) where T : class
        {
            T entity = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _appSettings.ApiBaseUrl;

                var response = await client.GetAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    entity = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    // entity = new T();
                    entity = default(T);
                }

                return entity;
            }
        }
        
    }
}