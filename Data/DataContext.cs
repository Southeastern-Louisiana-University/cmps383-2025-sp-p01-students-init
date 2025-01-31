using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Theater> Theaters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data: 3 pre-populated theater records
        modelBuilder.Entity<Theater>().HasData(
            new Theater { Id = 1, Name = "Lions Den Grande Theater", Address = "123 W University Ave", SeatCount = 200 },
            new Theater { Id = 2, Name = "Lions Den Mega Theater", Address = "456 Palace Dr", SeatCount = 150 },
            new Theater { Id = 3, Name = "Lions Den Green and Gold Theater", Address = "789 S Range Rd", SeatCount = 100 }
        );
    }
}
