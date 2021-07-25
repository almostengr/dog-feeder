using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Common.Client
{
    public abstract class BaseClient
    {
        public readonly HttpClient _httpClient;

        public BaseClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5000");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            var response = await _httpClient.PostAsync(route, ConvertToStringContent(entity));

            if (response.IsSuccessStatusCode)
            {
                entity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return entity;
        }

        public async Task<Entity> UpdateAsync<Entity>(string route, Entity entity) where Entity : class
        {
            var response = await _httpClient.PutAsync(route, ConvertToStringContent(entity));

            if (response.IsSuccessStatusCode)
            {
                entity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return entity;
        }

        private StringContent ConvertToStringContent<Entity>(Entity entity)
        {
            return new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        }

    }
}
