using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.DAL.Models;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    [Encrypted]
    public string PasswordHash { get; set; } = null!;
}
