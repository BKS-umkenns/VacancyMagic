using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.DAL.Models;

public class SearchQuery
{
    public long Id { get; set; }
    [Timestamp]
    public long? CreatedAt { get; set; } = DateTime.UtcNow.ToFileTime();

    public long UserId { get; set; }
    public User User { get; set; } = null!;
}
