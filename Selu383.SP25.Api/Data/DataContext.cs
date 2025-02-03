
using Microsoft.EntityFrameworkCore;

namespace Selu383.SP25.Api.Data
{
    public class DataContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes them to the base class
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities (tables)
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }

        // (Optional) Override OnModelCreating for custom configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: modelBuilder.Entity<Customer>().ToTable("tblCustomer");
        }
    }
}
