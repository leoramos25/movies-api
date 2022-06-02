using Microsoft.AspNetCore.Mvc;
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
    public IActionResult createMovie([FromBody] Movie movie)
    {
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
}