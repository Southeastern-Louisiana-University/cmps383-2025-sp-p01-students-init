using Selu383.SP25.Api.Data;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api.Seeding
{
    public class DbInitializer
    {
        internal static void Initialize(DataContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Hotel.Any()) return;

            var hotels = new Hotel[]
            {
            new Hotel{ Name = "Celeberty" },
            new Hotel{ Name = "Perkins Rowe" }
            //add other users
            };

            foreach (var hotel in hotels)
                dbContext.Hotel.Add(hotel);

            dbContext.SaveChanges();
        }
    }
}
