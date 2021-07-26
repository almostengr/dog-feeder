using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Enums;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IListClient
    {
        Task<IList<DayFrequency>> GetDayFrequencyListAsync();
    }
}