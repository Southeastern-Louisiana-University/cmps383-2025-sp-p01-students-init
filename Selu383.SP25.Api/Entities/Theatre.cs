using System.ComponentModel.DataAnnotations;
namespace Selu383.SP25.Api.Entities

{
    public class Theatre
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Seat must be greater than equal to 1 ")]

        public string Address { get; set; }

        [Required]
        public int SeatCount { get; set; }
    }
}
