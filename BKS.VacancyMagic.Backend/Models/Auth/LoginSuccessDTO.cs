namespace BKS.VacancyMagic.Backend.Models.Auth;

public class LoginSuccessDTO
{
    public string Token { get; set; } = null!;
    public bool Success { get; set; }
}
