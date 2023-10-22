namespace BKS.VacancyMagic.Backend.DAL.Models;

public class ServiceAuthorization
{
    public long Id { get; set; }
    public string AccessToken { get; set; } = null!;
    public string? RefreshToken { get; set; }
    public string? SecretKey { get; set; }

    public long UserId { get; set; }
    public long ServiceId { get; set; }

    public User User { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
