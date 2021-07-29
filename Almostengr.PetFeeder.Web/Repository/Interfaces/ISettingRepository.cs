using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;

namespace Almostengr.PetFeeder.Web.Repository
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
        Task<Setting> GetSettingByKeyAsync(string key);
    }
}