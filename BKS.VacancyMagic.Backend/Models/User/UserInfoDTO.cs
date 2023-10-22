namespace BKS.VacancyMagic.Backend.Models.User;

public class UserInfoDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set;}
    public string? MiddleName { get; set; }
    public string Email { get; set; } = null!;
}
