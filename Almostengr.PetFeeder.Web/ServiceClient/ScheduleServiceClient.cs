using System.Net.Http;

namespace Almostengr.PetFeeder.Web.ServiceClient
{
    public class ScheduleServiceClient : BaseServiceClient
    {
        public ScheduleServiceClient(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}