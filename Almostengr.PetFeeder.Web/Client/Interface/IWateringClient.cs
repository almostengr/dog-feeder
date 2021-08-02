using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface IWateringClient
    {
        Task<IList<WateringDto>> GetAllWateringsAsync();
        Task<IList<WateringDto>> GetLatestWateringsAsync();
        Task<WateringDto> GetWateringAsync(int id);
        Task<WateringDto> CreateWateringAsync(WateringDto wateringDto);
        Task<bool?> GetWaterBowlStatus();
    }
    
}