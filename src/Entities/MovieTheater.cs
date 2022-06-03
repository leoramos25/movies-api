using System.ComponentModel.DataAnnotations;

namespace src.Entities;

public class MovieTheater
{
    [Key]
    [Required]
    public long Id { get; set; }
    [Required(ErrorMessage = "Name cannot be null")]
    public string Name { get; set; }
    public int AddressFK { get; set; }
    public int ManagerFK { get; set; }
}