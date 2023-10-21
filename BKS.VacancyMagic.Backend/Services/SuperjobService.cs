using BKS.VacancyMagic.Backend.Common.Extensions;
using BKS.VacancyMagic.Backend.DAL;
using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.Vacancy;
using System.Text.Json;

namespace BKS.VacancyMagic.Backend.Services;

public class SuperjobService : IVacancy
{
    private readonly AppDbContext _dbContext;
    private readonly HttpClient _httpClient;
    public SuperjobService(AppDbContext dbContext, HttpClient httpClient)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
    }
    public string? BaseUrl { get; set; } = "https://api.superjob.ru/2.0";
    public string Title { get; set; } = "SuperJob";

    public async Task<AuthResultDTO> AuthorizationAsync(AuthRequestDTO authRequest, CancellationToken ct)
    {
        var authUrl = $"{BaseUrl}/oauth2/password/";
        var pass = "testpas123";
        var secretKey = "v3.r.137902953.2438a9ca6677da093e5068ff8b52c65119ccbd0e.db749930ceec732297cc24f351ef405d053c4466";

        authRequest.Password = authRequest.Password ?? pass;
        authRequest.SecretKey = authRequest.SecretKey ?? secretKey;

        var parameters = new Dictionary<string, string>
        {
            { "login", authRequest.Login! },
            { "password", authRequest.Password },
            { "client_id", authRequest.ClientId ?? "" },
            { "client_secret", authRequest.SecretKey }
        };

        var httpResult = await _httpClient.GetAsync($"{authUrl}?{parameters.ToQueryString()}", ct);

        var superjobResult = JsonSerializer.Deserialize<AuthResultSuperJob>(await httpResult.Content.ReadAsStringAsync(ct));

        return new AuthResultDTO
        {
            AccessToken = superjobResult?.access_token,
            ExpiresTime = superjobResult?.expires_in,
            RefreshToken = superjobResult?.refresh_token,
            TokenType = superjobResult?.token_type
        };
    }

    public async Task<List<VacancyRecordDTO?>> GetDataAsync<TPrompt>(TPrompt prompt, CancellationToken ct) where TPrompt : class
    {
        var vacanciesUrl = $"{BaseUrl}/vancies/";

        var s = prompt.ConvertToDictionary().ToQueryString();

        var httpResult = await _httpClient.GetAsync($"{vacanciesUrl}?{prompt.ConvertToDictionary().ToQueryString()}", ct);

        var superjobResult = JsonSerializer.Deserialize<VacancyRecordDTO>(await httpResult.Content.ReadAsStringAsync(ct));

        var result = new List<VacancyRecordDTO?> { superjobResult };

        return result;
    }

    public Task<ReplyStatusDTO> GetReplyStatusAsync(ServiceReplyDTO serviceReply, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ReplyDTO> ReplyAsync(VacancyRecordDTO record, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}

public class AuthResultSuperJob
{
    public string? access_token { get; set; }
    public string? refresh_token { get; set; }
    public int? expires_in { get; set; }
    public string? token_type { get; set; }
}
public class SuperJobVacancyPrompt
{
    public int? IdVacancy { get; set; }
    public int[]? Ids { get; set; }
    public int? IdClient { get; set; }
    public int? IdUser { get; set; }
    public int? IdResume { get; set; }
    public int? IdSubs { get; set; }
    public int? DatePublishedFrom { get; set; }
    public int? DatePublishedTo { get; set; }
    public int? SortNew { get; set; }
    public int? Published { get; set; }
    public bool? PublishedAll { get; set; }
    public bool? Archive { get; set; }
    public bool? NotArchive { get; set; }
    //По всей вакансии
    public string? Keyword { get; set; }
    public SuperjobKeywords[]? Keywords { get; set; }
    //By field (date default) or payment or ..
    public string? OrderField { get; set; }
    //asc\desc (default desc)
    public string? OrderDirection { get; set; }
    //1- 24h, 3 - 3d, 7 - week, 0 - alltime
    public int? Period { get; set; }
    public int? PaymentFrom { get; set; }
    public int? PaymentTo { get; set; }
    public int? NoAgreement { get; set; }
    public string? Town { get; set; }
    public int[]? M { get; set; }
    public int[]? T { get; set; }
    public int[]? O { get; set; }
    public int[]? C { get; set; }
    public int? Catalogues { get; set; }
    public int? PlaceOfWork { get; set; }
    public int? Moveable { get; set; }
    public int? Agency { get; set; }
    public int? TypeOfWork { get; set; }
    public int? Age { get; set; }
    public int? Gender { get; set; }
    public int? Education { get; set; }
    public int? Experience { get; set; }
    public string[]? DrivingLicence { get; set; }
    public int? DrivingParticular { get; set; }
    public int? Language { get; set; }
    public int? LangLevel { get; set; }
    //1 = имеет значение
    public int? LanguagesParticular { get; set; }
    //1 = не показывать вакансии со знанием языков
    public int? NoLang { get; set; }
}

public class SuperjobKeywords
{
    //Что искать: 1 — должность; 2 — название компании; 3 — должностные обязанности; 4 — требования к квалификации;5 — условия работы;10 — весь текст вакансии
    public int? Srws { get; set; }
    //Как искать: and — все слова; or — хотя бы одно слово; particular — точную фразу; nein — слова-исключения
    public string? Skwc { get; set; }
    //Ключевое слово
    public string? Keys { get; set; }
}