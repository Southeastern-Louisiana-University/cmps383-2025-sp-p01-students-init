using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Selu383.SP25.Api.Entity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public List<UserRole> UserRoles { get; set; } = new();

    }

    public class UserGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth
        {
            get; set;
        }

        public class UserCreateDto
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public DateTime DateOfBirth { get; set; }

            [Required]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            public string Password { get; set; }
        }


    }
}