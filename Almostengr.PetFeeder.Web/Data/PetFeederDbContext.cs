using Almostengr.PetFeeder.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.Web.Data
{
    public class PetFeederDbContext : DbContext
    {
        public PetFeederDbContext(DbContextOptions<PetFeederDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Alarm> Alarms { get; set; }
        public virtual DbSet<Feeding> Feedings { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Watering> Waterings { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alarm>().ToTable(nameof(Alarm).ToLower());
            modelBuilder.Entity<Feeding>().ToTable(nameof(Feeding).ToLower());
            modelBuilder.Entity<Schedule>().ToTable(nameof(Schedule).ToLower());
            modelBuilder.Entity<Setting>().ToTable(nameof(Setting).ToLower());
            modelBuilder.Entity<Watering>().ToTable(nameof(Watering).ToLower());
        }
    }
}