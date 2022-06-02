using Microsoft.EntityFrameworkCore;
using src.Entities;

namespace src.Database;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }

    public DbSet<Movie> movies { get; set; }
}