namespace BKS.VacancyMagic.Backend.DAL.Models;

public class UserCV
{
    public long Id { get; set; }
    public long ResumeId { get; set; }
    public long UserId { get; set; }
    public long ServiceId { get; set; }

    public User User { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
