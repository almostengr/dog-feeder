using Almostengr.DogFeeder.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.DogFeeder.Models
{
    public class DogFeederDbContext : DbContext
    {
        public DogFeederDbContext(DbContextOptions<DogFeederDbContext> options) : base(options)
        { }

        public virtual DbSet<Feeding> Feedings { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feeding>().ToTable(nameof(Feeding).ToLower());
            modelBuilder.Entity<Schedule>().ToTable(nameof(Schedule).ToLower());
        }
    }
}