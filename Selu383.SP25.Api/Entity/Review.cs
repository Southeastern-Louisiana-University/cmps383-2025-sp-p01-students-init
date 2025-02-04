using Selu383.SP25.Api.Data.Base;

namespace Selu383.SP25.Api.Entity
{
    public class Review : IEntityBase
    {
        public int Id { get; set; }
        public string review { get; set; }
        public int Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Movie Movie { get; set; }
        public int MovieId { get; set; }

    }

    public class ReviewsGetDto
    {
        public int Id { get; set; }
        public string review { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

    }

    public class ReviewsCreateDto
    {
        public string Review { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

    }

    public class ReviewsUpdateDto
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }

    }
}
