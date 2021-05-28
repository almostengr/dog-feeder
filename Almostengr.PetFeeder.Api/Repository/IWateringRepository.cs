using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IWateringRepository : IRepositoryBase<Watering>
    {
        // Task CreateWateringAsync(Watering watering);
        // Task<List<Watering>> GetAllWateringsAsync();
        // Task<Watering> GetWateringByIdAsync(int? id);
        Task<List<Watering>> GetRecentWateringsAsync();
        // void UpdateWatering(Watering watering);
    }
}