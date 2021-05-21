using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.Api.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DogFeederDbContext _dbContext;

        public BaseRepository(DogFeederDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task<IList<T>> GetAllAsync<T>()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IList<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(T entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

    }
}