using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Enums;

namespace Almostengr.PetFeeder.Web.Client.Interface
{
    public interface IListClient
    {
        Task<IList<DayFrequency>> GetDayFrequencyListAsync();
    }
}