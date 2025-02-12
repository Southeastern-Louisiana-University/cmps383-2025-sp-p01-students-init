using Selu383.SP25.Api.Data.Base;
using Selu383.SP25.Api.Entity;

namespace Selu383.SP25.Api.Data.Services
{
    public class ReviewsService : EntityBaseRepository<Review>, IReviewsService
    {
        public ReviewsService(DataContext context) : base(context) { }
    }
}