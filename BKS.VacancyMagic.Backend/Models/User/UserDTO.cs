using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.Models.User;

public class UserDTO
{
    [Required]
    public string? Login { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password{ get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
}
