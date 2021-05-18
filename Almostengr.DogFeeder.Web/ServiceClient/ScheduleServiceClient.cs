using System.Net.Http;

namespace Almostengr.DogFeeder.Web.ServiceClient
{
    public class ScheduleServiceClient : BaseServiceClient
    {
        public ScheduleServiceClient(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}