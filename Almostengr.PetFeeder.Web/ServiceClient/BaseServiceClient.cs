using System.Net.Http;

namespace Almostengr.PetFeeder.Web.ServiceClient
{
    public abstract class BaseServiceClient
    {
        private readonly HttpClient _httpClient;

        protected BaseServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}