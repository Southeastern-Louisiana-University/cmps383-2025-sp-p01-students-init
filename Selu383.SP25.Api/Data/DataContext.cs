using Microsoft.EntityFrameworkCore;

namespace Selu383.SP25.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Theater> Theater { get; set; } // Add DbSet for Theater

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Hotel
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel California", Address = "123 Sunset Blvd", Rating = 5 },
                new Hotel { Id = 2, Name = "Grand Budapest", Address = "456 Mountain Rd", Rating = 4 }
            );

            // Seed data for Theater
            modelBuilder.Entity<Theater>().HasData(
                new Theater { Id = 1, Name = "Main Street Theater", Address = "123 Main St" },
                new Theater { Id = 2, Name = "Downtown Cinema", Address = "456 Elm St" }
            );
        }
    }

    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
    }

    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
