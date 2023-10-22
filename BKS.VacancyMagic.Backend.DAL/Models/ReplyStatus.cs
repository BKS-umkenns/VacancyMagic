namespace BKS.VacancyMagic.Backend.DAL.Models;

public class ReplyStatus
{
    public long Id { get; set; }
    public string Status { get; set; } = null!;

    public long ServiceId { get; set; }

    public Service Service { get; set; } = null!;
}
