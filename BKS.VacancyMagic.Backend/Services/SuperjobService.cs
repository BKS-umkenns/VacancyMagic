using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.Vacancy;

namespace BKS.VacancyMagic.Backend.Services;

public class SuperjobService : IVacancy
{
    public string Title { get; set; } = "Superjob";

    public Task<ReplyStatusDTO> Authorization(AuthRequestDTO authRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<VacancyRecordDTO?>> GetData(string? prompt)
    {
        throw new NotImplementedException();
    }

    public Task<ReplyStatusDTO> GetReplyStatus(ServiceReplyDTO serviceReply)
    {
        throw new NotImplementedException();
    }

    public Task<ReplyDTO> Reply(VacancyRecordDTO record)
    {
        throw new NotImplementedException();
    }
}
