using Microsoft.AspNetCore.Mvc;
using Selu383.SP25.Api.Data.Services;
using Selu383.SP25.Api.Entity;

namespace Selu383.SP25.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheatersController : ControllerBase
    {
        private readonly ITheatersService _service;

        public TheatersController(ITheatersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var theaters = await _service.GetAll();
            return Ok(theaters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var theaterDetails = await _service.GetByIdAsync(id);
            if (theaterDetails == null) return NotFound();
            return Ok(theaterDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Theater theater)
        {
            if (theater == null)
            {
                return BadRequest("Theater data is required.");
            }

            // Validation for Name, Address, and SeatCount
            if (string.IsNullOrEmpty(theater.Name))
            {
                return BadRequest("Name is required.");
            }
            if (theater.Name.Length > 120)
            {
                return BadRequest("Name cannot be longer than 120 characters.");
            }
            if (string.IsNullOrEmpty(theater.Address))
            {
                return BadRequest("Address is required.");
            }
            if (theater.SeatCount < 1)
            {
                return BadRequest("SeatCount must be at least 1.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddAsync(theater);
            return CreatedAtAction(nameof(GetById), new { id = theater.Id }, theater);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Theater theater)
        {
            if (theater == null || id != theater.Id)
            {
                return BadRequest("Invalid request data.");
            }
            if (string.IsNullOrEmpty(theater.Name))
            {
                return BadRequest("Name is required.");
            }
            if (theater.Name.Length > 120)
            {
                return BadRequest("Name cannot be longer than 120 characters.");
            }
            if (string.IsNullOrEmpty(theater.Address))
            {
                return BadRequest("Address is required.");
            }
            if (theater.SeatCount < 1)
            {
                return BadRequest("SeatCount must be at least 1.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTheater = await _service.GetByIdAsync(id);
            if (existingTheater == null)
            {
                return NotFound("Theater not found.");
            }

            await _service.UpdateAsync(id, theater);
            return Ok(theater);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTheater = await _service.GetByIdAsync(id);
            if (existingTheater == null)
            {
                return NotFound("Theater not found.");
            }

            await _service.DeleteAsync(id);
            return Ok("Theater deleted successfully.");
        }
    }
}
