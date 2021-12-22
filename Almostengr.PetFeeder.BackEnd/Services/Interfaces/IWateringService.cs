using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObjects;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface IWateringService
    {
        Task<WateringDto> GetWateringAsync(int id);
        Task<List<WateringDto>> GetAllWateringsAsync();
        Task<WateringDto> CreateWateringAsync(WateringDto wateringDto);
    }
}