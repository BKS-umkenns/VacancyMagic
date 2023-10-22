using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.DAL.Models;

public class Reply
{
    public long Id { get; set; }
    public string ReplyId { get; set; } = null!;
    [Timestamp]
    public long? CreatedAt { get; set; } = DateTime.UtcNow.ToFileTime();
    public string VacancyId { get; set; } = null!;

    public long UserId { get; set; }
    public long ServiceId { get; set; }
    public Service Service { get; set; } = null!;
    public User User { get; set; } = null!;
}
