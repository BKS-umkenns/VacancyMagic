using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.DAL.Models;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }

    [Encrypted]
    public string PasswordHash { get; set; } = null!;
}
