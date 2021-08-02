using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Enums;
using Almostengr.PetFeeder.Web.Client.Interface;

namespace Almostengr.PetFeeder.Web.Client
{
    public class ListClient : BaseClient, IListClient
    {
        public async Task<IList<DayFrequency>> GetDayFrequencyListAsync()
        {
            return await GetAsync<IList<DayFrequency>>("/api/lists/dayfrequency");
        }
    }
}