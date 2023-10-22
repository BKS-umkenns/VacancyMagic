namespace BKS.VacancyMagic.Backend.Models;

public class ErrorDTO
{
    public ErrorObject? error { get; set; }
    public string? info { get; set; }
}

public class ErrorObject
{
    public int code { get; set; }
    public string? error { get; set; }
    public string? message { get; set; }
}