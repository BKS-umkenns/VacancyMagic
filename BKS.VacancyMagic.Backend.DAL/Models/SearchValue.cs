namespace BKS.VacancyMagic.Backend.DAL.Models;

public class SearchValue
{
    public long Id { get; set; }
    public string VacancyId { get; set; } = null!;

    public long ReplyId { get; set; }
    public long UserId { get; set; }
    public long ServiceId { get; set; }

    public User User { get; set; } = null!;
    public Reply Reply { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
