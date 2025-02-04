using Selu383.SP25.Api.Data.Base;
using Selu383.SP25.Api.Entity;

namespace Selu383.SP25.Api.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(ApplicationDbContext context) : base(context) { }
    }
}
