using Selu383.SP25.Api.Data;
using Selu383.SP25.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Selu383.SP25.Api.Seeding
{
    public class DbInitializer
    {
        internal static void Initialize(DataContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            var theaters = new Theater[]
            {
                new Theater { Id = 1, Name = "Lions Den Grande Theater", Address = "123 W University Ave", SeatCount = 26 },
                new Theater { Id = 2, Name = "Lions Den Mega Theater", Address = "456 Palace Dr", SeatCount = 30 },
                new Theater { Id = 3, Name = "Lions Den Green and Gold Theater", Address = "789 S Range Rd", SeatCount = 28 }
            };
            
            foreach (var theater in theaters)
                dbContext.Theaters.Add(theater); // Corrected property name
            
            dbContext.SaveChanges();
        }
    }    
}
