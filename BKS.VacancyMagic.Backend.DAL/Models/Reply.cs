using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.DAL.Models;

public class Reply
{
    public long Id { get; set; }
    [Timestamp]
    public DateTime CreatedAt { get; set; }
    public string VacancyId { get; set; } = null!;

    public long UserId { get; set; }
    public string ServiceId { get; set; } = null!;
    public Service Service { get; set; } = null!;
    public User User { get; set; } = null!;
}
