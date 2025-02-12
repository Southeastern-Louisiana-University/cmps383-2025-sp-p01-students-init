using Microsoft.EntityFrameworkCore;
namespace Selu383.SP25.Api;



    public class DataContext : DbContext
    {
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    {
    }

    public DbSet<Theater> Theaters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Theater>().HasData(
            new Theater { Id = 1, Name = "Hammond AMC", Address = "1234 W Thomas Street", SeatCount = 300 },
            new Theater { Id = 2, Name = "Ponchatoula AMC", Address = "1234 N Dakota Street", SeatCount = 150 },
            new Theater { Id = 3, Name = "Amite AMC", Address = "1234 S London Street", SeatCount = 500 });
    }
}
