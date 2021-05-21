using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.Api.Repository
{
    public abstract class BaseRepository
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
    }
}