using Selu383.SP25.Api.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Selu383.SP25.Api.Entity
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Review Review { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public List<Showtime> Showtimes { get; set; }
    }

    public class MovieGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public List<Showtime> Showtimes { get; set; }
    }


    public class MovieCreateDto
    {
        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required, MaxLength(100)]
        public string Genre { get; set; }

        [Required, Range(1, 600)]
        public int Duration { get; set; }

        [Required, Url]
        public string ImageUrl { get; set; }

        [Required, Url]
        public string TrailerUrl { get; set; }
    }

}
