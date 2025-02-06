using Microsoft.AspNetCore.Mvc;
using Selu383.SP25.Api.Data;
using System.Diagnostics.Eventing.Reader;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api.Controllers
{
    [ApiController]
    [Route("theater")]
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
                      Name = Theater.Name
                  }).ToList();

            return Ok("Test");
        }
    }
}
