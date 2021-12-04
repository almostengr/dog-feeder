using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObjects;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface IWaterBowlRepository
    {
        Task<WaterBowlDto> GetWaterBowlAsync(int id);
        Task<List<WaterBowlDto>> GetRecentWaterings();
        Task<List<WaterBowlDto>> GetAllWaterings();
        Task<WaterBowlDto> AddWaterBowlAsync(WaterBowlDto waterBowl);
    }
}