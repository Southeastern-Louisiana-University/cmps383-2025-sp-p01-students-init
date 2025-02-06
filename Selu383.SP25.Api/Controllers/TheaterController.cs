using Microsoft.AspNetCore.Mvc;
using Selu383.SP25.Api.Data;
using System.Diagnostics.Eventing.Reader;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api.Controllers
{
    [ApiController]
    [Route("/api/theaters")]
    public class TheaterController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TheaterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _dataContext
                .Set<Theater>()
                .Select(Theater => new TheaterGetDto
                {
                    Id = Theater.Id,
                    Name = Theater.Name,
                    Address = Theater.Address,
                    SeatCount = Theater.SeatCount
                }).ToList();

            return Ok(data); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _dataContext
                .Set<Theater>()
                .Where(Theater => Theater.Id == id)
                .Select(Theater => new TheaterGetDto
                {
                    Id = Theater.Id,
                    Name = Theater.Name,
                    Address = Theater.Address,
                    SeatCount = Theater.SeatCount
                }).FirstOrDefault();

            if (data == null)
            {
                return NotFound();  
            }

            return Ok(data);  
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            var theater = _dataContext.Set<Theater>().FirstOrDefault(t => t.Id == id);

            
            if (theater == null)
            {
                return NotFound(); 
            }

            
            _dataContext.Set<Theater>().Remove(theater);
            _dataContext.SaveChanges(); 

            
            return NoContent(); 
        }

        [HttpPost]
        public IActionResult CreateTheater([FromBody] TheaterCreateDto createDto)
        {
            
            if (string.IsNullOrEmpty(createDto.Name))
            {
                return BadRequest("Name cannot be empty");
            }
            if (createDto.Name.Length > 120)
            {
                return BadRequest("Name is too long");
            }

            
            var theaterToCreate = new Theater
            {
                Name = createDto.Name,
                Address = createDto.Address,
                SeatCount = createDto.SeatCount
            };

            
            _dataContext.Set<Theater>().Add(theaterToCreate);
            _dataContext.SaveChanges();

            
            var theaterReturn = new TheaterGetDto
            {
                Id = theaterToCreate.Id,
                Name = theaterToCreate.Name,
                Address = theaterToCreate.Address,
                SeatCount = theaterToCreate.SeatCount
            };

            
            return CreatedAtAction(nameof(GetById), new { id = theaterToCreate.Id }, theaterReturn);
        }

    }
}
