using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Selu383.SP25.Api.Entities;
using Selu383.SP25.Api.Data;
using AutoMapper;

namespace Selu383.SP25.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        static private List<Theatre> Theatres = new List<Theatre>
        {
            new Theatre
            {
                Id = 1,
                Address = "Laffayete",
                Name = "AMC",
                SeatCount = 29
            },
            new Theatre {
                Id = 2,
                Address = "New York",
                Name = "Wholesome",
                SeatCount = 33
            },
        };
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dataContext;
        public TheatreController(IMapper mapper, ApplicationDbContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<List<Theatre>> GetTheatres()
        {
            var theatre = _dataContext.Theatres.ToList();
            var theatreDto = _mapper.Map<List<TheatreDto>>(theatre);
            return Ok(theatreDto);
        }
        [HttpGet("{id}")]
        public ActionResult<Theatre>GetTheatreById(int id)
        {
            var theatre = _dataContext.Theatres.FirstOrDefault(x => x.Id == id);
            if(theatre is null)
            {
                return NotFound();
            }
            var theatreDto = _mapper.Map<TheatreDto>(theatre);
            return Ok(theatreDto);
        }

        [HttpPost]
        public ActionResult<Theatre> AddTheatre(TheatreCreateDto newTheatreDto)
        {
            if (newTheatreDto is null)
            {
                return BadRequest();
            }
           var newTheatre = _mapper.Map<Theatre>(newTheatreDto);
            _dataContext.Theatres.Add(newTheatre);
            _dataContext.SaveChanges();
            var theatreDto = _mapper.Map<TheatreDto>(newTheatre);
            return CreatedAtAction(nameof(GetTheatreById), new { id = theatreDto.Id }, theatreDto);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateTheatre(int id, TheatreUpdateDto updateTheatreDto)
        {
            var existingTheatre = _dataContext.Theatres.FirstOrDefault(x => x.Id == id);

            if (existingTheatre == null)
            {
                return NotFound(); 
            }

            _mapper.Map(updateTheatreDto, existingTheatre);
            _dataContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteTheatre(int id)
        {
            var theatre = _dataContext.Theatres.FirstOrDefault(x =>x.Id == id);
            if (theatre is null)
            {
                return BadRequest();
            }
           _dataContext.Theatres.Remove(theatre);
           _dataContext.SaveChanges();
            return NoContent();
        }
        
    }
}
