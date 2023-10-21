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
    public string Title { get; set; } = "Superjob";

    public async Task<AuthResultDTO> AuthorizationAsync(AuthRequestDTO authRequest, CancellationToken ct)
    {
        var authUrl = $"{BaseUrl}/oauth2/password/";
        var pass = "testpas123";
        var secretKey = "v3.r.137902953.2438a9ca6677da093e5068ff8b52c65119ccbd0e.db749930ceec732297cc24f351ef405d053c4466";
        authRequest.Password = pass;
        authRequest.SecretKey = secretKey;

        var httpResult = await _httpClient.GetAsync($"{authUrl}?login={authRequest.Login!}&password={authRequest.Password}" +
            $"&client_id={authRequest.ClientId}&client_secret={authRequest.SecretKey}", ct);

        var superjobResult = JsonSerializer.Deserialize<AuthResultSuperJob>(await httpResult.Content.ReadAsStringAsync(ct));

        return new AuthResultDTO
        {
            AccessToken = superjobResult?.access_token,
            ExpiresTime = superjobResult?.expires_in,
            RefreshToken = superjobResult?.refresh_token,
            TokenType = superjobResult?.token_type
        };
    }

    public Task<List<VacancyRecordDTO?>> GetDataAsync(string? prompt, CancellationToken ct)
    {
        throw new NotImplementedException();
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
