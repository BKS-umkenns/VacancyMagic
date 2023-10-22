namespace BKS.VacancyMagic.Backend.Models.Vacancy;

public class VacancyRecordDTO
{
    public VacancyRecordObject[]? objects { get; set; }
    public long? total { get; set; }
    public string? corrected_keyword { get; set; }
    public bool? more { get; set; }
    public ErrorDTO? error { get; set; }
}


public class VacancyRecordObject
{
    public long id { get; set; }
    public long id_client { get; set; }
    public int? payment_from { get; set; }
    public int? payment_to { get; set; }
    public decimal? payment { get; set; }
    public string? profession { get; set; }
    public string? work { get; set; }
    public string? currency { get; set; }
    public string? candidat { get; set; }
    public bool? moveable { get; set; }
    public IdTitle? type_of_work { get; set; }
    public IdTitle? place_of_work { get; set; }
    public IdTitle? education { get; set; }
    public IdTitle? experience { get; set; }
    public IdTitle? maritalstatus { get; set; }
    public IdTitle? children { get; set; }
    public IdTitle? agency { get; set; }
    public IdTitle? town { get; set; }
    public int? age_from { get; set; }
    public int? age_to { get; set; }
    public IdTitle? gender { get; set; }
    public Uri? link { get; set; }
    public string? firm_name { get; set; }
    public string? firm_activity { get; set; }
    public int? views_count { get; set; }
}
public class IdTitle
{
    public int id { get; set; }
    public string? title { get; set; }
}