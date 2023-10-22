namespace BKS.VacancyMagic.Backend.Models.Vacancy;

public class ReplyStatusDTO
{
    public string? Status { get; set; }
    public string? StatusMessage { get; set; }
}

public class SuperjobResponseReply
{
    public List<SuperjobObjectReply>? objects { get; set; }
    public long? total { get; set; }
    public bool? more { get; set; }
}

public class SuperjobObjectReply
{
    public long? id { get; set; }
    public long? id_resume { get; set; }
    public string? status { get; set; }
}
