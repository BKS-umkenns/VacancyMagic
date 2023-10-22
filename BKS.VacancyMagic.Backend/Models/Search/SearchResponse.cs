using System.Text.Json.Serialization;

namespace BKS.VacancyMagic.Backend.Models.Search;

public class SearchResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? response { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? error_code { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? error_message { get; set; }
}
