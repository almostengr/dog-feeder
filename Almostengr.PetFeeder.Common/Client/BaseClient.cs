using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

// based on example from https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client

namespace Almostengr.PetFeeder.Common.Client
{
    public abstract class BaseClient
    {
        public readonly HttpClient _httpClient;

        public BaseClient()
        {
            _httpClient = new HttpClient();
            // _httpClient.BaseAddress = new Uri("https://localhost:5000");
            _httpClient.BaseAddress = new Uri("http://localhost:5000");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Entity> GetAsync<Entity>(string route) where Entity : class
        {
            Entity responseEntity = null;

            var response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                responseEntity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return responseEntity;
        }

        public async Task<bool?> GetAsyncBool(string route)
        {
            bool? responseEntity = null;

            var response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                responseEntity = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
            }

            return responseEntity;
        }

        public async Task<HttpStatusCode> DeleteAsync<Entity>(string route) where Entity : class
        {
            var response = await _httpClient.DeleteAsync(route);

            return response.StatusCode;
        }

        // public async Task<Entity> CreateAsync<Entity>(string route, Entity entity) where Entity : class
        public async Task<Uri> CreateAsync<Entity>(string route, Entity entity) where Entity : class
        {
            Entity responseEntity = null;

            var response = await _httpClient.PostAsync(route, ConvertToStringContent(entity));

            if (response.IsSuccessStatusCode)
            {
                responseEntity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            // return responseEntity;
            return response.Headers.Location;
        }

        public async Task<Entity> UpdateAsync<Entity>(string route, Entity entity) where Entity : class
        {
            Entity responseEntity = null;

            var response = await _httpClient.PutAsync(route, ConvertToStringContent(entity));

            if (response.IsSuccessStatusCode)
            {
                responseEntity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return responseEntity;
        }

        private StringContent ConvertToStringContent<Entity>(Entity entity)
        {
            return new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        }

    }
}
