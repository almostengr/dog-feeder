using Microsoft.EntityFrameworkCore;

namespace Almostengr.DogFeeder.Models
{
    public class DogFeederDbContext : DbContext
    {
        public DogFeederDbContext(DbContextOptions<DogFeederDbContext> options) : base()
        {

        }

        public DbSet<Feeding> Feedings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}