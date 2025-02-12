namespace Selu383.SP25.Api.Entity
{
    public class Showtime
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public int AvailableSeats { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }

    public class ShowtimeGetDto
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public int AvailableSeats { get; set; }
        public int MovieId { get; set; }
        public Movie Movie {  set; get; }

    }

    public class ShowtimeCreateDto
    {
        public string StartTime { get; set; }
        public int AvailableSeats { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { set; get; }
    }
}
