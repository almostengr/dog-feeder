using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IFeedingClient
    {
        Task<IList<Feeding>> GetAllFeedingsAsync();
        Task<Feeding> GetFeedingAsync(int id);
        Task<Feeding> CreateFeedingAsync(Feeding feeding);
    }
}