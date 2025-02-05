using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Theatre tables


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Theatre>().HasData(
                new Theatre { Id = 1, Name = "vatte ko Hall", Address = "Hammond", SeatCount = 34 },
                new Theatre { Id = 2, Name = "aakashHall", Address = "BatonRouge", SeatCount = 23}
                );


        }
        public DbSet<Theatre> Theatres { get; set; }
    }
}