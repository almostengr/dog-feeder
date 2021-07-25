using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;

namespace Amostengr.PetFeeder.Common.Client.Interface
{
    public interface IListClient
    {
        Task<IList<DayFrequency>> GetDayFrequencyListAsync();
    }
}