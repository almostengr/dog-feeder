using System.Net.Http;

namespace Almostengr.PetFeeder.Web.ServiceClient
{
    public class FeedingServiceClient : BaseServiceClient
    {
        public FeedingServiceClient(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}