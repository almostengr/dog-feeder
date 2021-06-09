using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Repository
{
    public abstract class RepositoryBase<Entity> : IRepositoryBase<Entity> where Entity : ModelBase
    {
        private readonly PetFeederDbContext _dbContext;
        private readonly ILogger<RepositoryBase<Entity>> _logger;
        private DbSet<Entity> _table = null;

        public RepositoryBase(PetFeederDbContext dbContext, ILogger<RepositoryBase<Entity>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _table = _dbContext.Set<Entity>();
        }

        public void Delete(Entity entity)
        {
            _table.Remove(entity);
        }

        public async Task<IList<Entity>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(Entity entity)
        {
            await _table.AddAsync(entity);
        }

        public void Update(Entity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IList<Entity> entities)
        {
            _table.UpdateRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}