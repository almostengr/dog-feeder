using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;

namespace Almostengr.PetFeeder.Web.Repository
{
    public interface IFeedingRepository : IRepositoryBase<Feeding>
    {
        Task<IList<Feeding>> GetLatestAsync();
    }
}