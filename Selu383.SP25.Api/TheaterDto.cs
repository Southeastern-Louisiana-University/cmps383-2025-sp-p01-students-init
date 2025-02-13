﻿using System.ComponentModel.DataAnnotations;

namespace Selu383.SP25.Api
{
    public class TheaterDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
         [MaxLength(120)]
        public String Name { get; set; } = string.Empty;
        [Required]
        public String Address { get; set; } = string.Empty;
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Seat count must be atleast 1")]
        public int SeatCount { get; set; }

    }
    public class TheaterCreateDto
    {
        

        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "SeatCount must be at least 1")]
        public int SeatCount { get; set; }
    }

    public class TheaterUpdateDto
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "SeatCount must be at least 1")]
        public int SeatCount { get; set; }
    }

}
