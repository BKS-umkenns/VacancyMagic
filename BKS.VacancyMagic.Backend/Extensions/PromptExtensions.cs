using BKS.VacancyMagic.Backend.Models.Search;
using System.Text.Json;

namespace BKS.VacancyMagic.Backend.Extensions;

public static class PromptExtensions
{
    public static SearchResultDTO? ToSearchObject(this string? searchResult)
    {
        return JsonSerializer.Deserialize<SearchResultDTO>(searchResult ?? "");
    }
}
