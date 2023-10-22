namespace BKS.VacancyMagic.Backend.DAL.Models;

public class SearchTag
{
    public long Id { get; set; }
    public byte Weight { get; set; }

    public long SearchQueryId { get; set; }
    public long TagId { get; set; }
    public Tag Tag { get; set; } = null!;
    public SearchQuery SearchQuery { get; set; } = null!;
}
