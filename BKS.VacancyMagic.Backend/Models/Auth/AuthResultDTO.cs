namespace BKS.VacancyMagic.Backend.Models.Auth;

public class AuthResultDTO
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public int? ExpiresTime { get; set; }
    public string? TokenType { get; set; }
}
