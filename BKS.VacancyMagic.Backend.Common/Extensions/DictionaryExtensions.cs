namespace BKS.VacancyMagic.Backend.Common.Extensions;

public static class DictionaryExtensions
{
    public static string ToQueryString(this Dictionary<string, string> parameters)
    {
        List<string> keyValuePairs = new List<string>();
        foreach (var kvp in parameters)
        {
            keyValuePairs.Add($"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}");
        }
        return string.Join("&", keyValuePairs);
    }

    public static Dictionary<string, string> ConvertToDictionary(this object obj)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        foreach (var property in obj.GetType().GetProperties())
        {
            dictionary[property.Name] = property.GetValue(obj)?.ToString();
        }

        return dictionary;
    }
}
