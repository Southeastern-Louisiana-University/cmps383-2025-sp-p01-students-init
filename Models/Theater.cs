using System.ComponetModel.DataAnnotations:

public class Theater
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Seat count must be at least 1.")]
    public int SeatCount { get; set; }
}