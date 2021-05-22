using System.Threading.Tasks;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IBaseRepository
    {
        Task SaveChangesAsync();
    }
}