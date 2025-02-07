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
            modelBuilder.Entity<Theaters>().HasData(
                new Theaters { Id = 1, Name = "vatte ko Hall", Address = "Hammond", SeatCount = 34 },
                new Theaters { Id = 2, Name = "aakashHall", Address = "BatonRouge", SeatCount = 23}
                );


        }
        public DbSet<Theaters> Theatres { get; set; }
    }
}