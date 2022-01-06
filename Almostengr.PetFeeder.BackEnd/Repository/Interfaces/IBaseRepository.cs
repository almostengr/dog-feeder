using System.Threading.Tasks;

namespace Almostengr.PetFeeder.BackEnd.Repository.Interfaces
{
    public interface IBaseRepository
    {
        Task<bool> SaveChangesAsync();
        // Task<int> SaveChangesAsync();
    }
}