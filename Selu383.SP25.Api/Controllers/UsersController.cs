
using Selu383.SP25.Api.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Selu383.SP25.Api.Entity.UserGetDto;
namespace Selu383.SP25.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public UsersController(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserGetDto>>> GetAll()
        {
            var users = await _context.Users
                .Select(x => new UserGetDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    DateOfBirth = x.DateOfBirth
                })
                .ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDto>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserGetDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserGetDto>> Create([FromBody] UserCreateDto newUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new User
            {
                UserName = newUserDto.UserName,
                FirstName = newUserDto.FirstName,
                LastName = newUserDto.LastName,
                Email = newUserDto.Email,
                DateOfBirth = newUserDto.DateOfBirth
            };

            var result = await _userManager.CreateAsync(newUser, newUserDto.Password);

            if (result.Succeeded)
            {
                var userDto = new UserGetDto
                {
                    Id = newUser.Id,
                    UserName = newUser.UserName,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    DateOfBirth = newUser.DateOfBirth
                };

                return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, userDto);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserGetDto>> Edit(int id, [FromBody] UserCreateDto updatedUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.UserName = updatedUserDto.UserName;
            existingUser.FirstName = updatedUserDto.FirstName;
            existingUser.LastName = updatedUserDto.LastName;
            existingUser.Email = updatedUserDto.Email.ToLowerInvariant();
            existingUser.DateOfBirth = updatedUserDto.DateOfBirth;

            var result = await _userManager.UpdateAsync(existingUser);

            if (result.Succeeded)
            {
                var userDto = new UserGetDto
                {
                    Id = existingUser.Id,
                    UserName = existingUser.UserName,
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    Email = existingUser.Email,
                    DateOfBirth = existingUser.DateOfBirth
                };

                return Ok(userDto);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

    }
}
