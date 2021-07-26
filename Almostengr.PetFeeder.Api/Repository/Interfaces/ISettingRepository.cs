using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
        Task<Setting> GetSettingByKeyAsync(string key);
    }
}