using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Theatre tables


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Theater>().HasData(
                new Theater { Id = 1, Name = "vatte ko Hall", Address = "Hammond", SeatCount = 34 },
                new Theater { Id = 2, Name = "aakashHall", Address = "BatonRouge", SeatCount = 23}
                );


        }
        public DbSet<Theater> Theatres { get; set; }
    }
}