using System.ComponentModel.DataAnnotations;

namespace src.Dto;

public class MovieTheaterDTO
{
    [Required(ErrorMessage = "Name cannot be null")]
    public string Name { get; set; }
    public int AddressFK { get; set; }
    public int ManagerFK { get; set; }
}