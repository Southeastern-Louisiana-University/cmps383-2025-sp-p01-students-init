# 🎭 Theater E-Commerce Site

## 📌 Overview
This is a **theater e-commerce** application built using **ASP.NET Core**. It allows users to browse movies, book tickets, and manage their schedules. The project follows a clean architecture with **Entity Framework Core (EF Core)** for database management and **Swagger** for API documentation.

---

## 🚀 Getting Started

### 1⃣ **Clone the Repository**
```sh
git clone https://github.com/Southeastern-Louisiana-University/cmps383-2025-sp-p01-daniel-hall.git
```

### 2⃣ **Setup the Database**
- Open **Package Manager Console (PMC)** in **Visual Studio** and run:

```sh
Add-Migration InitialCreate
Update-Database
```

- This creates the necessary database tables.

---

## 🎬 Creating a New Entity and Controller

Follow these steps to add a new entity and expose it via an API.

### 1⃣ **Create a New Entity**
- Inside the `Entity` folder, create a new **C# class**.
- Make sure you inherit `IEntityBase` class
- Example: `Movie.cs`
  
```csharp
using Selu383.SP25.Api.Data.Base;

namespace Selu383.SP25.Api.Entity
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
```

---

### 2⃣ **Add Entity to Database Context**
- Open `ApplicationDbContext.cs` and register the new entity.

```csharp
public DbSet<Movie> Movies { get; set; }
```

---

### 3⃣ **Create a Service for the Entity**
- Inside `Data/Services`, create a new interface:

```csharp
using Selu383.SP25.Api.Data.Base;
using Selu383.SP25.Api.Entity;

namespace Selu383.SP25.Api.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
    }
}
```

- Then, create the service implementation:

```csharp
using Selu383.SP25.Api.Data.Base;
using Selu383.SP25.Api.Entity;

namespace Selu383.SP25.Api.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(ApplicationDbContext context) : base(context) { }
    }
}
```

---

### 4⃣ **Register the Service in Dependency Injection**
- Open `Program.cs` and add:

```csharp
builder.Services.AddScoped<IMoviesService, MoviesService>();
```

---

### 5⃣ **Create a Controller**
- Inside `Controllers`, create `MoviesController.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;
using Selu383.SP25.Api.Data.Services;
using Selu383.SP25.Api.Entity;
using System.Threading.Tasks;

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
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _moviesService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _moviesService.AddAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _moviesService.UpdateAsync(id, movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moviesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
```

---

### 6⃣ **Run Database Migration for New Entity**
```sh
Add-Migration AddMovieEntity
Update-Database
```

---

### 7⃣ **Run the Application**
```sh
dotnet run
```
or press **F5** in Visual Studio.

---

### 8⃣ **Test in Swagger**
- Navigate to:
```
https://localhost:7001/swagger/index.html
```
- You should see **Movies API** listed.

---
