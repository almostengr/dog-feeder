using System.Linq;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Data;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Repository
{

    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        private readonly PetFeederDbContext _dbContext;

        public SettingRepository(PetFeederDbContext dbContext, ILogger<SettingRepository> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public async Task<Setting> GetSettingByKeyAsync(string key)
        {
            return await _dbContext.Settings
                .Where(s => s.Key == key)
                .SingleOrDefaultAsync();
        }

    }
}