using Microsoft.AspNetCore.Mvc;
using Selu383.SP25.Api.Data;
using Selu383.SP24.Tests.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Selu383.SP25.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheatersController : ControllerBase
    {
        private readonly DataContext _context;

        public TheatersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/theaters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheaterDto>>> GetTheaters()
        {
            var theaters = await _context.Theater
                .Select(t => new TheaterDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Address = t.Address
                })
                .ToListAsync();

            return Ok(theaters);
        }

        // GET: api/theaters/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TheaterDto>> GetTheater(int id)
        {
            var theater = await _context.Theater.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }

            return Ok(new TheaterDto
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address
            });
        }

        // POST: api/theaters
        [HttpPost]
        public async Task<ActionResult<TheaterDto>> CreateTheater([FromBody] TheaterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Length > 120)
            {
                return BadRequest("Invalid theater name");
            }

            if (string.IsNullOrWhiteSpace(dto.Address))
            {
                return BadRequest("Theater address is required");
            }

            var theater = new Theater
            {
                Name = dto.Name,
                Address = dto.Address
            };

            _context.Theater.Add(theater);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTheater), new { id = theater.Id }, dto);
        }

        // PUT: api/theaters/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheater(int id, [FromBody] TheaterDto dto)
        {
            if (id <= 0 || id != dto.Id)
            {
                return BadRequest();
            }

            var theater = await _context.Theater.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Length > 120)
            {
                return BadRequest("Invalid theater name");
            }

            if (string.IsNullOrWhiteSpace(dto.Address))
            {
                return BadRequest("Theater address is required");
            }

            theater.Name = dto.Name;
            theater.Address = dto.Address;

            _context.Entry(theater).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/theaters/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            var theater = await _context.Theater.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }

            _context.Theater.Remove(theater);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
