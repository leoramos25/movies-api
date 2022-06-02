using Microsoft.AspNetCore.Mvc;
using src.Entities;

namespace src.Controllers;

[ApiController]
[Route("movies")]
public class MovieController : ControllerBase
{
    private static List<Movie> _movies = new List<Movie>();
    private static int id = 1;

    [HttpPost]
    public IActionResult createMovie([FromBody] Movie movie)
    {
        movie.Id = id++;
        _movies.Add(movie);
        return CreatedAtAction(nameof(findMovieById), new { id = movie.Id}, movie);
    }

    [HttpGet]
    public IActionResult findAllMovies()
    {
        return Ok(_movies);
    }

    [HttpGet("{id}")]
    public IActionResult findMovieById(int id)
    {
        var movie = _movies.FirstOrDefault(movie => movie.Id == id);

        if (movie != null)
        {
            Ok(movie);
        }

        return NotFound();
    }
}