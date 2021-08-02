using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface IPowerClient
    {
        Task<PowerDto> PostAsync(PowerDto powerDto);
    }
}