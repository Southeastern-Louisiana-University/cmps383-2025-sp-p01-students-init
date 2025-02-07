using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Dtos;
using Selu383.SP25.Api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Selu383.SP25.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TheatersController : ControllerBase
{
    private readonly DataContext _context;

    public TheatersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<TheaterDto>>> GetTheaters()
    {
        var theaters = await _context.Theaters
            .Select(t => new TheaterDto
            {
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
                SeatCount = t.SeatCount
            })
            .ToListAsync();

        return Ok(theaters);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TheaterDto>> GetTheater(int id)
    {
        var theater = await _context.Theaters
            .Select(t => new TheaterDto
            {
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
                SeatCount = t.SeatCount
            })
            .FirstOrDefaultAsync(t => t.Id == id);

        if (theater == null)
        {
            return NotFound();
        }

        return Ok(theater);
    }
}
