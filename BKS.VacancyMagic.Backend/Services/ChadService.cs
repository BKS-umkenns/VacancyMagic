using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Search;
using System.Text.Json;

namespace BKS.VacancyMagic.Backend.Services;

public class ChadService : ISearch
{
    private readonly HttpClient _httpClient;
    public ChadService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public string ApiKey { get; set; } = "chad-a23f8f3406e9449b8ff19dd01edc057epzlwaxyg";
    public Uri? ChadUri { get; set; } = new Uri("https://ask.chadgpt.ru/api/public/gpt-3.5");

    public async Task<SearchResponse> SearchAsync(string prompt, CancellationToken ct)
    {
        var requestData = new { message = prompt, api_key = ApiKey };
        var requestContent = JsonContent.Create(requestData);

        var httpResult = await _httpClient.PostAsync($"{ChadUri!}", requestContent, ct);

        var result = JsonSerializer.Deserialize<SearchResponse>(await httpResult.Content.ReadAsStringAsync(ct));

        return result!;
    }
}
