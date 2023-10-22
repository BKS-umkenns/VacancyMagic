﻿using BKS.VacancyMagic.Backend.DAL;
using BKS.VacancyMagic.Backend.Extensions;
using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models;
using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.Vacancy;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BKS.VacancyMagic.Backend.Services;

public class SuperjobService : IVacancy
{
    private readonly AppDbContext _dbContext;
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger _logger;
    public SuperjobService(AppDbContext dbContext, HttpClient httpClient, IHttpContextAccessor httpContextAccessor, ILogger<SuperjobService> logger)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }
    public string? BaseUrl { get; set; } = "https://api.superjob.ru/2.0";
    public string Title { get; set; } = "SuperJob";

    public async Task<AuthResultDTO> AuthorizationAsync(AuthRequestDTO authRequest, CancellationToken ct)
    {
        var authUrl = authRequest.GrantType == "refresh_token" ? $"{BaseUrl}/oauth2/refresh_token/" : $"{BaseUrl}/oauth2/password/";
        var secretKey = "v3.r.137902953.2438a9ca6677da093e5068ff8b52c65119ccbd0e.db749930ceec732297cc24f351ef405d053c4466";
        authRequest.SecretKey = authRequest.SecretKey ?? secretKey;

        Dictionary<string, string?> parameters;

        if (authRequest.GrantType == "refresh_token")
        {
            var user = await _dbContext.Users.SingleAsync(x => x.Name == _httpContextAccessor.HttpContext!.User.Identity!.Name, ct);
            var serviceAuthorization = await _dbContext.ServiceAuthorizations.OrderBy(x => x.Id).FirstAsync(x => x.UserId == user.Id);
            parameters = new Dictionary<string, string?>
            {
                { "refresh_token", serviceAuthorization.RefreshToken },
                { "client_id", authRequest.ClientId },
                { "client_secret", authRequest.SecretKey == secretKey ? serviceAuthorization.SecretKey ?? secretKey : authRequest.SecretKey }
            };
        }
        else
        {
            var pass = "testpas123";
            authRequest.Password = authRequest.Password ?? pass;
            parameters = new Dictionary<string, string?>
            {
                { "login", authRequest.Login },
                { "password", authRequest.Password },
                { "client_id", authRequest.ClientId },
                { "client_secret", authRequest.SecretKey }
            };
        }

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

    public async Task<VacancyRecordDTO?> GetDataAsync<TPrompt>(TPrompt prompt, CancellationToken ct) where TPrompt : class
    {
        var vacanciesUrl = $"{BaseUrl}/vacancies/";

        var httpResult = await RequestData(vacanciesUrl, prompt.ConvertToDictionary().ToQueryString(), ct);

        var strResult = await httpResult!.Content.ReadAsStringAsync(ct);

        if (strResult!.Contains("error"))
        {
            var error = JsonSerializer.Deserialize<ErrorDTO>(strResult);
            if (error != null && error.error!.code == 410)
            {
                await AuthorizationAsync(new AuthRequestDTO { GrantType = "refresh_token" }, ct);
                httpResult = await RequestData(vacanciesUrl, prompt.ConvertToDictionary().ToQueryString(), ct);
            }
        }

        await SaveSearchQueryToDB(ct);

        strResult = await httpResult!.Content.ReadAsStringAsync(ct);

        var result = JsonSerializer.Deserialize<VacancyRecordDTO>(strResult);

        return result;
    }

    public async Task<ReplyStatusDTO?> GetReplyStatusAsync(ServiceReplyDTO serviceReply, CancellationToken ct)
    {
        var replyUrl = $"{BaseUrl}/send_cv_on_vacancy/";

        await SetHttpHeadersAsync(ct);

        var queryParams = new Dictionary<string, string?> { { "id_cv", "1" }, { "id_vacancy", "1" }, { "comment", "1" } }.ToQueryString();

        var httpResult = await _httpClient.PostAsync($"{replyUrl}?{queryParams}", ct);

        var strResult = await httpResult!.Content.ReadAsStringAsync(ct);

        if (strResult!.Contains("error"))
        {
            var error = JsonSerializer.Deserialize<ErrorDTO>(strResult);
            if (error != null && error.error!.code == 410)
            {
                await AuthorizationAsync(new AuthRequestDTO { GrantType = "refresh_token" }, ct);
                httpResult = await RequestData(vacanciesUrl, prompt.ConvertToDictionary().ToQueryString(), ct);
            }
        }

        strResult = await httpResult!.Content.ReadAsStringAsync(ct);

        var result = JsonSerializer.Deserialize<ReplyStatusDTO>(strResult);

        return result;
    }

    public async Task<ReplyDTO?> ReplyAsync(VacancyRecordObject record, CancellationToken ct)
    {
        var replyUrl = $"{BaseUrl}/send_cv_on_vacancy/";

        await SetHttpHeadersAsync(ct);

        var requestData = new { id_cv = 1, id_vacancy = 1, comment = "" };
        var requestContent = JsonContent.Create(requestData);

        var httpResult = await _httpClient.PostAsync(replyUrl, requestContent, ct);

        var strResult = await httpResult!.Content.ReadAsStringAsync(ct);

        if (strResult!.Contains("error"))
        {
            var error = JsonSerializer.Deserialize<ErrorDTO>(strResult);
            if (error != null && error.error!.code == 410)
            {
                await AuthorizationAsync(new AuthRequestDTO { GrantType = "refresh_token" }, ct);
                httpResult = await _httpClient.PostAsync(replyUrl, requestContent, ct);
            }

            if (error != null && error.error!.code == 403)
            {
                return null;
            }
        }

        var statusReply = JsonSerializer.Deserialize<VacancyReplyResponse>(strResult);
        if (statusReply!.result == false) return null;

        var result = new ReplyDTO { ReplyId = record.id.ToString() };

        return result;
    }

    private async Task<HttpResponseMessage?> RequestData(string vacanciesUrl, string? prompt, CancellationToken ct)
    {
        await SetHttpHeadersAsync(ct);

        return await _httpClient.GetAsync($"{vacanciesUrl}?{prompt}", ct);
    }

    private async Task SaveSearchQueryToDB(CancellationToken ct)
    {
        try
        {
            var user = await _dbContext.Users.SingleAsync(user => user.Name == _httpContextAccessor.HttpContext!.User.Identity!.Name, ct);
            await _dbContext.SearchQueries.AddAsync(new DAL.Models.SearchQuery
            {
                CreatedAt = new DateTime(),
                UserId = user.Id
            });
            await _dbContext.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    private async Task SetHttpHeadersAsync(CancellationToken ct)
    {
        var user = await _dbContext.Users.SingleAsync(user => user.Name == _httpContextAccessor.HttpContext!.User.Identity!.Name, ct);
        var serviceAuthorization = await _dbContext.ServiceAuthorizations.OrderBy(x => x.Id).FirstAsync(x => x.UserId == user.Id);

        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", serviceAuthorization.AccessToken);
        _httpClient.DefaultRequestHeaders.Add("X-Api-App-Id", serviceAuthorization.SecretKey ?? "v3.r.137902953.2438a9ca6677da093e5068ff8b52c65119ccbd0e.db749930ceec732297cc24f351ef405d053c4466");
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

public class VacancyReplyResponse
{
    public bool? result { get; set; }
}
