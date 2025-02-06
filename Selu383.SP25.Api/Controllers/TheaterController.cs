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

            return Ok("Test");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
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

            return Ok("Test");
        }

        [HttpPost]
        public IActionResult CreateTheater([FromBody] TheaterCreateDto createDto)
        {

            if (createDto.Name.Length > 120 )
            {
                return BadRequest("Name is too long");
            }
            if (createDto.Name == "")
            {
                return BadRequest("Name cannot be empty");
            }
            var TheaterToCreate = new Theater
            {
                Name = createDto.Name,
                Address = createDto.Address,
                SeatCount = createDto.SeatCount

            };

            _dataContext.SaveChanges();

            var TheaterReturn = new TheaterGetDto
            {
                Id = TheaterToCreate.Id,
                Name = TheaterToCreate.Name,
                Address = TheaterToCreate.Address,
                SeatCount = TheaterToCreate.SeatCount
            };

            return Ok("Ok");
        }

    }
}
