using BKS.VacancyMagic.Backend.DAL;
using BKS.VacancyMagic.Backend.Extensions;
using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.Search;
using BKS.VacancyMagic.Backend.Models.Vacancy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BKS.VacancyMagic.Backend.Controllers;

[Route("api/[controller]")]
public class VacancyController : Controller
{
    private readonly IVacancy _vacancyService;
    private readonly ISearch _searchService;
    private readonly AppDbContext _dbContext;
    private readonly ILogger _logger;
    private readonly IHttpContextAccessor _httpContextAccesor;
    public VacancyController(IVacancy vacancyService, ISearch searchService, AppDbContext dbContext, ILogger<VacancyController> logger,
        IHttpContextAccessor httpContextAccessor)
    {
        _vacancyService = vacancyService;
        _searchService = searchService;
        _dbContext = dbContext;
        _logger = logger;
        _httpContextAccesor = httpContextAccessor;
    }

    /// <summary>
    /// testMethod
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<SearchResultDTO>> SearchVacancies([FromQuery][FromBody]string prompt, CancellationToken ct)
    {
        var searchResultString = await _searchService.SearchAsync(prompt, ct);

        var result = await _vacancyService.GetDataAsync(searchResultString.response!.ToSearchObject()!, ct);

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    [HttpGet("auth")]
    public async Task<ActionResult<AuthResultDTO>> AuthorizationInService(AuthRequestDTO req, CancellationToken ct)
    {
        var result = await _vacancyService.AuthorizationAsync(req, ct);

        try
        {
            var user = await _dbContext.Users.SingleAsync(user => user.Name == _httpContextAccesor.HttpContext!.User.Identity!.Name, ct);
            var service = await _dbContext.Services.SingleAsync(service => service.Name == _vacancyService.Title, ct);

            await _dbContext.ServiceAuthorizations.AddAsync(new DAL.Models.ServiceAuthorization
            {
                AccessToken = result!.AccessToken!,
                RefreshToken = result.RefreshToken,
                ServiceId = service.Id,
                UserId = user.Id
            }, ct);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    [HttpPost]
    public async Task<ActionResult<List<VacancyRecordDTO>?>> ReplyVacancy(VacancyRecordDTO vacancy, CancellationToken ct)
    {
        var result = await _vacancyService.ReplyAsync(vacancy, ct);

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }
}
