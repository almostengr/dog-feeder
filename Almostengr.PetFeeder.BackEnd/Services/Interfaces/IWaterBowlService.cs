using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObjects;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface IWaterBowlService
    {
        Task<WaterBowlDto> AddWaterBowlAsync(WaterBowlDto waterBowl);
        // Task<WaterBowlDto> UpdateWaterBowlAsync(WaterBowlDto waterBowl);
        // Task<WaterBowlDto> DeleteWaterBowlAsync(WaterBowlDto waterBowl);
        Task<WaterBowlDto> GetWaterBowlAsync(int id);
        Task<List<WaterBowlDto>> GetAllWateringsAsync();
        Task<List<WaterBowlDto>> GetRecentWateringsAsync();
    }
}