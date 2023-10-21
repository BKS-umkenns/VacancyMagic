using BKS.VacancyMagic.Backend.Models.Search;

namespace BKS.VacancyMagic.Backend.Interfaces;

public interface ISearch
{
    public string ApiKey { get; set; }
    public Uri? ChadUri { get; set; }
    public Task<SearchResponse> SearchAsync(string prompt, CancellationToken ct);
}
