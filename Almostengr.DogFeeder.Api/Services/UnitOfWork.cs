// using Almostengr.DogFeeder.Api.Models;
// using Microsoft.EntityFrameworkCore;

// namespace Almostengr.DogFeeder.Api.Services
// {
//     public class UnitOfWork : DbContext, IUnitOfWork
//     {
//         public UnitOfWork() : base("MvcSettings") { }
//         public DbSet<Setting> Settings { get; set; }

//         // protected override void OnModelCreating(DbModelBuilder modelBuilder)
//         // {
//         //     modelBuilder.Entity<Setting>()
//         //                 .HasKey(x => new { x.Name, x.Type });

//         //     modelBuilder.Entity<Setting>()
//         //                 .Property(x => x.Value)
//         //                 .IsOptional();

//         //     base.OnModelCreating(modelBuilder);
//         // }
//     }
// }