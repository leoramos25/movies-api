using System.ComponentModel.DataAnnotations;

namespace src.Entities;

public class Movie
{
    public Movie(int id, string title, string director, string genre, int duration)
    {
        Id = id;
        Title = title;
        Director = director;
        Genre = genre;
        Duration = duration;
    }

    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Title cannot be empty")]
    public string Title { get; private set; }
    [Required(ErrorMessage = "Director cannot be empty")]
    public string Director { get; private set; }
    public string Genre { get; private set; }
    [Range(1, 400, ErrorMessage = "Duration should between 1 a 400 minutes")]
    public int Duration { get; private set; }
}