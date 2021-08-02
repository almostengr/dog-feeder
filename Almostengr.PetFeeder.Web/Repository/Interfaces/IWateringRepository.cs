using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;

namespace Almostengr.PetFeeder.Web.Repository
{
    public interface IWateringRepository : IRepositoryBase<Watering>
    {        
        Task<Watering> GetByIdAsync(int id);
        Task<List<Watering>> GetLatestWateringsAsync();
    }
}