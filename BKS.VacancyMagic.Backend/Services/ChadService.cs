using BKS.VacancyMagic.Backend.Common.Configuration;
using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Search;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BKS.VacancyMagic.Backend.Services;

public class ChadService : ISearch
{
    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;
    public ChadService(HttpClient httpClient, IOptionsSnapshot<AppSettings> optionsSnapshot)
    {
        _httpClient = httpClient;
        _appSettings = optionsSnapshot.Value;
    }
    public string ApiKey { get; set; } = "chad-a23f8f3406e9449b8ff19dd01edc057epzlwaxyg";
    public Uri? ChadUri { get; set; } = new Uri("https://ask.chadgpt.ru/api/public/gpt-3.5");

    public async Task<SearchResponse> SearchAsync(string prompt, CancellationToken ct)
    {
        var fullPrompt = $"{_appSettings.Prompt}. вот запрос: {prompt}";

        var requestData = new { message = fullPrompt, api_key = ApiKey };
        var requestContent = JsonContent.Create(requestData);

        var httpResult = await _httpClient.PostAsync($"{ChadUri!}", requestContent, ct);

        var result = JsonSerializer.Deserialize<SearchResponse>(await httpResult.Content.ReadAsStringAsync(ct));

        return result!;
    }
}
