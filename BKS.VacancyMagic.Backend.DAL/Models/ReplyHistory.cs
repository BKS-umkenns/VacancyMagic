using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.DAL.Models;

public class ReplyHistory
{
    public long Id { get; set; }
    public long StatusId { get; set; }
    [Timestamp]
    public long? CreatedAt { get; set; } = DateTime.UtcNow.ToFileTime();
    public long ReplyId { get; set; }


    public Reply Reply { get; set; } = null!;
    public ReplyStatus ReplyStatus { get; set; } = null!;
}
