using Microsoft.EntityFrameworkCore;
using src.Entities;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }

    public DbSet<Movie> movies { get; private set; }
}