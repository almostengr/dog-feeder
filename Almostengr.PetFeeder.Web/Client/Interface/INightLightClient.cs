using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface INightLightClient
    {
        Task<NightLightDto> CreateNightLightAsync(NightLightDto nightLightDto);
    }
}