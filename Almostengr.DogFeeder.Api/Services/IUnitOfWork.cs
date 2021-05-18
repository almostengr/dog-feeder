using Almostengr.DogFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.DogFeeder.Api.Services
{
    public interface IUnitOfWork
    {
        DbSet<Setting> Settings { get; set; }
        int SaveChanges();
    }
}