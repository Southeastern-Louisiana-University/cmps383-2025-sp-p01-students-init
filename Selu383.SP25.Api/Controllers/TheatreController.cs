using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Selu383.SP25.Api.Entities;
using AutoMapper;

namespace Selu383.SP25.Api.Controllers
{
    [Route("api/theaters")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        static private List<Theater> Theatres = new List<Theater>
        {
            new Theater
            {
                Id = 1,
                Address = "Laffayete",
                Name = "AMC",
                SeatCount = 29
            },
            new Theater {
                Id = 2,
                Address = "New York",
                Name = "Wholesome",
                SeatCount = 33
            },
        };
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public TheatersController(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<List<Theater>> GetTheatres()
        {
            var theatre = _dataContext.Theaters.ToList();
            var theatreDto = _mapper.Map<List<TheaterDto>>(theatre);
            return Ok(theatreDto);
        }
        [HttpGet("{id}")]
        public ActionResult<Theater>GetTheatreById(int id)
        {
            var theatre = _dataContext.Theaters.FirstOrDefault(x => x.Id == id);
            if(theatre is null)
            {
                return NotFound();
            }
            var theatreDto = _mapper.Map<TheaterDto>(theatre);
            return Ok(theatreDto);
        }

        [HttpPost]
        public ActionResult<Theater> AddTheatre(TheaterCreateDto newTheatreDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("ModelState is invalid:");
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                var newTheatre = _mapper.Map<Theater>(newTheatreDto);
                _dataContext.Theaters.Add(newTheatre);
                _dataContext.SaveChanges();
                var theatreDto = _mapper.Map<TheaterDto>(newTheatre);
                return CreatedAtAction(nameof(GetTheatreById), new { id = theatreDto.Id }, theatreDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return NotFound(ex.Message);

            }

        }


        [HttpPut("{id}")]
        public IActionResult UpdateTheatre(int id, TheaterUpdateDto updateTheatreDto)
        {
            var existingTheatre = _dataContext.Theaters.FirstOrDefault(x => x.Id == id);

            if (existingTheatre == null)
            {
                return NotFound(); 
            }

            _mapper.Map(updateTheatreDto, existingTheatre);
            _dataContext.SaveChanges();

            return Ok(existingTheatre);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteTheatre(int id)
        {
            var theatre = _dataContext.Theaters.FirstOrDefault(x =>x.Id == id);
            if (theatre is null)
            {
                return NotFound();
            }
           _dataContext.Theaters.Remove(theatre);
           _dataContext.SaveChanges();
            return Ok();
        }
        
    }
}
