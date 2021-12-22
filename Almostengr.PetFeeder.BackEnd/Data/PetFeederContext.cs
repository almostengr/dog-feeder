using Almostengr.PetFeeder.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.PetFeeder.BackEnd.Data
{
    public class PetFeederContext : DbContext
    {
        public PetFeederContext (DbContextOptions<PetFeederContext> options) : base(options)
        {
        }

        public DbSet<Feeding> Feedings { get; set; }
        public DbSet<Watering> Waterings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}