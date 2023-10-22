namespace BKS.VacancyMagic.Backend.DAL.Models;

public class Tag
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;

    public long ServiceId { get; set; }
    public Service Service { get; set; } = null!;
}
