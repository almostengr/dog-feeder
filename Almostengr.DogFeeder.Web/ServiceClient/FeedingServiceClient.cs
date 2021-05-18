using System.Net.Http;

namespace Almostengr.DogFeeder.Web.ServiceClient
{
    public class FeedingServiceClient : BaseServiceClient
    {
        public FeedingServiceClient(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}