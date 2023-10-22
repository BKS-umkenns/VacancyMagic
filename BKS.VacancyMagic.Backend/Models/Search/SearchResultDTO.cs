namespace BKS.VacancyMagic.Backend.Models.Search;

public class SearchResultDTO
{
    public string? keyword { get; set; }
    public int? experience { get; set; }
    public int? gender { get; set; }
    public string? education { get; set; } 
    public string? workload { get; set; }
    public int? payment_from { get; set; }
    public int? payment_to { get; set; }
    public int? period { get; set; }
    public string? town { get; set; }
}
