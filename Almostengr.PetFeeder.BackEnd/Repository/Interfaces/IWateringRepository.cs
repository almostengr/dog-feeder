using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObjects;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface IWateringRepository
    {
        Task<WateringDto> CreateWateringAsync(WateringDto wateringDto);
        Task<WateringDto> GetWateringAsync(int id);
        Task<WateringDto> UpdateWateringAsync(WateringDto wateringDto);
        Task<List<WateringDto>> GetAllWateringsAsync();
        Task DeleteWateringAsync(int id);
    }
}