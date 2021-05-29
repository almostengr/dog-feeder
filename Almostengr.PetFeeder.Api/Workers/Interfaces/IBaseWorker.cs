using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Workers
{
    public interface IBaseWorker
    {
        Task PostAsync<Entity>(string route, Entity entity) where Entity : ModelBase;
    }
}