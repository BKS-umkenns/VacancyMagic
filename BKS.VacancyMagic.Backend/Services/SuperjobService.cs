using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.Vacancy;

namespace BKS.VacancyMagic.Backend.Services;

public class SuperjobService : IVacancy
{
    public string Title { get; set; } = "Superjob";

    public Task<AuthResultDTO> AuthorizationAsync(AuthRequestDTO authRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<VacancyRecordDTO?>> GetDataAsync(string? prompt)
    {
        throw new NotImplementedException();
    }

    public Task<ReplyStatusDTO> GetReplyStatusAsync(ServiceReplyDTO serviceReply)
    {
        throw new NotImplementedException();
    }

    public Task<ReplyDTO> ReplyAsync(VacancyRecordDTO record)
    {
        throw new NotImplementedException();
    }
}
