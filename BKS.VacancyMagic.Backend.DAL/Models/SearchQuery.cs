using System.ComponentModel.DataAnnotations;

namespace BKS.VacancyMagic.Backend.DAL.Models;

public class SearchQuery
{
    public long Id { get; set; }
    [Timestamp]
    public DateTime CreatedAt { get; set; }

    public long UserId { get; set; }
    public User User { get; set; } = null!;
}
