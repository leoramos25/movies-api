using Microsoft.AspNetCore.Mvc;
using src.Entities;

namespace src.Controllers;

[ApiController]
[Route("movies")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();

    [HttpPost]
    public void createMovie([FromBody] Movie movie)
    {
        movies.Add(movie);
        Console.WriteLine(movie.Title);
    }
}