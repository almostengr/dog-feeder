using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Amostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class ListClient : BaseClient, IListClient
    {
        public async Task<IList<DayFrequency>> GetDayFrequencyListAsync()
        {
            return await GetAsync<IList<DayFrequency>>("/lists/dayfrequency");
        }
    }
}