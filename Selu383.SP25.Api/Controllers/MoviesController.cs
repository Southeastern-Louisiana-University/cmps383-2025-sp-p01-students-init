using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selu383.SP25.Api.Data.Services;
using Selu383.SP25.Api.Entity;

namespace Selu383.SP25.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _moviesService.GetAll();
            var movieDtos = movies.Select(movie => new MovieGetDto
            {
                Id = movie.Id,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description,
                Genre = movie.Genre,
                Duration = movie.Duration,
                ImageUrl = movie.ImageUrl,
                TrailerUrl = movie.TrailerUrl,
                Showtimes = movie.Showtimes
            });

            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _moviesService.GetByIdAsync(id);
            if (movie == null) return NotFound();

            var movieDto = new MovieGetDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description,
                Genre = movie.Genre,
                Duration = movie.Duration,
                ImageUrl = movie.ImageUrl,
                TrailerUrl = movie.TrailerUrl,
                Showtimes = movie.Showtimes
            };

            return Ok(movieDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var movie = new Movie
            {
                Title = movieDto.Title,
                ReleaseDate = movieDto.ReleaseDate,
                Description = movieDto.Description,
                Genre = movieDto.Genre,
                Duration = movieDto.Duration,
                ImageUrl = movieDto.ImageUrl,
                TrailerUrl = movieDto.TrailerUrl
            };

            await _moviesService.AddAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MovieCreateDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingMovie = await _moviesService.GetByIdAsync(id);
            if (existingMovie == null) return NotFound();

            existingMovie.Title = movieDto.Title;
            existingMovie.ReleaseDate = movieDto.ReleaseDate;
            existingMovie.Description = movieDto.Description;
            existingMovie.Genre = movieDto.Genre;
            existingMovie.Duration = movieDto.Duration;
            existingMovie.ImageUrl = movieDto.ImageUrl;
            existingMovie.TrailerUrl = movieDto.TrailerUrl;

            await _moviesService.UpdateAsync(id, existingMovie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingMovie = await _moviesService.GetByIdAsync(id);
            if (existingMovie == null) return NotFound();

            await _moviesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
