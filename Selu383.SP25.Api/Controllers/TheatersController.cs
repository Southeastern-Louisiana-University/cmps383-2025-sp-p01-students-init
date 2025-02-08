using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Dtos;
using Selu383.SP25.Api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Selu383.SP25.Api.Controllers;

[ApiController]
[Route("api/theaters")]
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
    [HttpPost]
    public async Task<ActionResult<TheaterDto>> CreateTheater(TheaterDto dto)
    {

        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest();

        if (dto.Name.Length > 120)
            return BadRequest();

        if (string.IsNullOrWhiteSpace(dto.Address))
            return BadRequest();


        var theater = new Theater
        {
            Name = dto.Name,
            Address = dto.Address,
            SeatCount = dto.SeatCount
        };

        _context.Theaters.Add(theater);
        await _context.SaveChangesAsync();

       
        dto.Id = theater.Id; 

        return CreatedAtAction(nameof(GetTheater), new { id = theater.Id }, dto);
    }
}