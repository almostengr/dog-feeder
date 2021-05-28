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
        private DbSet<Entity> table = null;

        public RepositoryBase(PetFeederDbContext dbContext, ILogger<RepositoryBase<Entity>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Delete(Entity entity)
        {
            table.Remove(entity);
        }

        public async Task<IList<Entity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task CreateAsync(Entity entity)
        {
            await table.AddAsync(entity);
        }

        public void Update(Entity entity)
        {
            _dbContext.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}