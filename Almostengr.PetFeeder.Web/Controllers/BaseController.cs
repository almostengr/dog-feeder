using System.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        internal readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<BaseController> _logger;
        private readonly Encoding _encoding;
        public Uri BackEndUrl;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;

            _httpClient.BaseAddress = new Uri("http://localhost:5000");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // _encoding = Encoding.ASCII;
            _encoding = Encoding.UTF8;
        }

        public async Task<Entity> GetAsync<Entity>(string route) where Entity : class
        {
            Entity entity = null;

            var response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                entity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return entity;
        }

        public async Task<Entity> DeleteAsync<Entity>(string route) where Entity : class
        {
            Entity entity = null;

            var response = await _httpClient.DeleteAsync(route);

            if (response.IsSuccessStatusCode)
            {
                entity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return entity;
        }

        public async Task<Entity> CreateAsync<Entity>(string route, Entity entity) where Entity : class
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(entity), _encoding, "application/json");
            var response = await _httpClient.PostAsync(route, stringContent);

            if (response.IsSuccessStatusCode)
            {
                entity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return entity;
        }

        public async Task<Entity> UpdateAsync<Entity>(string route, Entity entity) where Entity : class
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(entity), _encoding, "application/json");
            var response = await _httpClient.PutAsync(route, stringContent);

            if (response.IsSuccessStatusCode)
            {
                entity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return entity;
        }

    }
}