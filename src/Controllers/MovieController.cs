using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Database;
using src.Dto;
using src.Entities;

namespace src.Controllers;

[ApiController]
[Route("movies")]
public class MovieController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public MovieController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult createMovie([FromBody] MovieDTO movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);

        _context.movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(findMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> findAllMovies()
    {
        return _context.movies;
    }

    [HttpGet("{id}")]
    public IActionResult findMovieById(int id)
    {
        var movie = _context.movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPut("{id}")]
    public IActionResult updateMovie(int id, [FromBody] MovieDTO updatedMovie)
    {
        var movie = _context.movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        _mapper.Map(updatedMovie, movie);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteMovie(int id)
    {
        var movie = _context.movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }
}