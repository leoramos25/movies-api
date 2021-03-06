using System.ComponentModel.DataAnnotations;

namespace src.Dto;

public class MovieDTO
{
    public MovieDTO(string title, string director, string genre, int duration)
    {
        Title = title;
        Director = director;
        Genre = genre;
        Duration = duration;
    }

    [Required(ErrorMessage = "Title cannot be null")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Director cannot be null")]
    public string Director { get; set; }
    public string Genre { get; set; }
    [Range(1, 400, ErrorMessage = "Duration should between 1 a 400 minutes")]
    public int Duration { get; set; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}