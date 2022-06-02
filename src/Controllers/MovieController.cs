using Microsoft.AspNetCore.Mvc;
using src.Database;
using src.Dto;
using src.Entities;

namespace src.Controllers;

[ApiController]
[Route("movies")]
public class MovieController : ControllerBase
{
    private MovieContext _movieContext;

    public MovieController(MovieContext movieContext)
    {
        _movieContext = movieContext;
    }

    [HttpPost]
    public IActionResult createMovie([FromBody] CreateMovieDTO movieDto)
    {
        var movie = new Movie{
            Title = movieDto.Title,
            Director = movieDto.Director,
            Genre = movieDto.Genre,
            Duration = movieDto.Duration
        };

        _movieContext.movies.Add(movie);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(findMovieById), new { id = movie.Id}, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> findAllMovies()
    {
        return _movieContext.movies;
    }

    [HttpGet("{id}")]
    public IActionResult findMovieById(int id)
    {
        var movie = _movieContext.movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPut("{id}")]
    public IActionResult updateMovie(int id, [FromBody] CreateMovieDTO updatedMovie) {
        var movie = _movieContext.movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) {
            return NotFound();
        }
        
        movie.Title = updatedMovie.Title;
        movie.Director = updatedMovie.Director;
        movie.Genre = updatedMovie.Director;
        movie.Duration = updatedMovie.Duration;

        _movieContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteMovie(int id) {
        var movie = _movieContext.movies.FirstOrDefault(movie => movie.Id == id);
        
        if (movie == null) {
            return NotFound();
        }

        _movieContext.Remove(movie);
        _movieContext.SaveChanges();

        return NoContent();
    }
}