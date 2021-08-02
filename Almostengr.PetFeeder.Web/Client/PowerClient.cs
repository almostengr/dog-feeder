using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client
{
    public class PowerClient : BaseClient, IPowerClient
    {
        public async Task<PowerDto> PostAsync(PowerDto powerDto)
        {
            return await PostAsync<PowerDto>("/api/power", powerDto);
        }
    }
}