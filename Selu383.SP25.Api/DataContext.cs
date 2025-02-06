using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Models;

namespace Selu383.SP25.Api;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Theater> Theaters { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Theater>().HasData(
            new Theater
            {
                Id = 1,
                Name = "AMC Hammond Square 8",
                Address = "1200 W University Ave, Hammond, LA 70401",
                SeatCount = 1200
            },
            new Theater
            {
                Id = 2,
                Name = "Grand Cinema Slidell",
                Address = "1950 Gause Blvd W, Slidell, LA 70460",
                SeatCount = 800
            },
            new Theater
            {
                Id = 3,
                Name = "Movie Tavern Covington",
                Address = "201 N US Highway 190, Covington, LA 70433",
                SeatCount = 950
            }
        );
    }
}