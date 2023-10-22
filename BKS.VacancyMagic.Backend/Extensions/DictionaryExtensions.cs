namespace BKS.VacancyMagic.Backend.Extensions;

public static class DictionaryExtensions
{
    public static string ToQueryString(this Dictionary<string, string?> parameters)
    {
        List<string> keyValuePairs = new ();
        foreach (var kvp in parameters)
        {
            if (kvp.Value != null)
            {
                keyValuePairs.Add($"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}");
               // keyValuePairs.Add($"{kvp.Key}={kvp.Value}");
            }
        }
        return string.Join("&", keyValuePairs);
    }

    public static Dictionary<string, string?> ConvertToDictionary(this object obj)
    {
        Dictionary<string, string?> dictionary = new ();

        foreach (var property in obj.GetType().GetProperties())
        {
            dictionary[property.Name] = property.GetValue(obj)?.ToString();
        }

        return dictionary;
    }
}
