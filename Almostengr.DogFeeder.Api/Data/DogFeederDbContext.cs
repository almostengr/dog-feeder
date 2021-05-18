using Almostengr.DogFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.DogFeeder.Models
{
    public class DogFeederDbContext : DbContext
    {
        public DogFeederDbContext(DbContextOptions<DogFeederDbContext> options) : base(options)
        { }

        public DbSet<Feeding> Feedings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}