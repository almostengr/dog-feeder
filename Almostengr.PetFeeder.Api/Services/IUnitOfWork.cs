using Almostengr.PetFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.Api.Services
{
    public interface IUnitOfWork
    {
        DbSet<Setting> Settings { get; set; }
        int SaveChanges();
    }
}