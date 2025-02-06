using Selu383.SP25.Api.Data.Base;
using Selu383.SP25.Api.Entity;

namespace Selu383.SP25.Api.Data.Services
{
    public class TheatersService : EntityBaseRepository<Theater>, ITheatersService
    {
        public TheatersService(DataContext context) : base(context) { }

    }
}
