using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Database;
using src.Dto;
using src.Entities;

namespace src.Controllers;

[ApiController]
[Route("movieTheaters")]
public class MovieTheaterController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public MovieTheaterController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult createMovieTheater([FromBody] MovieTheaterDTO movieTheaterDTO)
    {
        var movieTheater = _mapper.Map<MovieTheater>(movieTheaterDTO);

        _context.movieTheaters.Add(movieTheater);
        _context.SaveChanges();

        return CreatedAtAction(nameof(findMovieTheaterById), new { id = movieTheater.Id }, movieTheater);
    }

    [HttpGet]
    public IEnumerable<MovieTheater> findAllMovieTheaters()
    {
        return _context.movieTheaters;
    }

    [HttpGet("{id}")]
    public IActionResult findMovieTheaterById(int id)
    {
        var movieTheater = _context.movieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater == null)
        {
            return NotFound();
        }

        return Ok(movieTheater);
    }

    [HttpPut("{id}")]
    public IActionResult updateMovieTheater(int id, [FromBody] MovieTheaterDTO movieTheaterDTO)
    {
        var movieTheater = _context.movieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater == null)
        {
            return NotFound();
        }

        _mapper.Map(movieTheaterDTO, movieTheater);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete]
    public IActionResult deleteMovieTheater(int id)
    {
        var movieTheater = _context.movieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater == null)
        {
            return NotFound();
        }

        _context.Remove(movieTheater);
        _context.SaveChanges();

        return NoContent();
    }
}