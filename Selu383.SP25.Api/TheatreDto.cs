using System.ComponentModel.DataAnnotations;

namespace Selu383.SP25.Api
{
    public class TheatreDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public String Name { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Seat count must be atleast 1")]
        public int SeatCount { get; set; }

    }
    public class TheatreCreateDto
    {
        

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "SeatCount must be at least 1")]
        public int SeatCount { get; set; }
    }

    public class TheatreUpdateDto
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "SeatCount must be at least 1")]
        public int SeatCount { get; set; }
    }

}
