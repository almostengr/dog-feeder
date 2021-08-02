using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface IBaseClient
    {
        Task<Entity> GetAsync<Entity>(string route);
        Task<Entity> DeleteAsync<Entity>(string route);
        Task<Entity> CreateAsync<Entity>(string route, Entity entity);
        Task<Entity> UpdateAsync<Entity>(string route, Entity entity);
    }
}