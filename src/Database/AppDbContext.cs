using Microsoft.EntityFrameworkCore;
using src.Entities;

namespace src.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> movies { get; set; }
    public DbSet<MovieTheater> movieTheaters { get; set; }
}