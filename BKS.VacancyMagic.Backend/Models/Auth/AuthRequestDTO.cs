namespace BKS.VacancyMagic.Backend.Models.Auth;

public class AuthRequestDTO
{
    public string? ClientId { get; set; }
    public string? SecretKey { get; set; }
    public string? Code { get; set; }
    public string? GrantType { get; set; }
    public Uri? RedirectUri { get; set; }

    public string? Login { get; set; }
    public string? Password { get; set; }
}
