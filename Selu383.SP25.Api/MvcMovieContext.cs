using Microsoft.EntityFrameworkCore;

namespace Selu383.SP25.Api
{
    internal class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Food> FoodOptions { get; set; }

    }

    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}