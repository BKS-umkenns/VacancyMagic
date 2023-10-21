using BKS.VacancyMagic.Backend.DAL;
using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.Search;
using BKS.VacancyMagic.Backend.Models.Vacancy;
using Microsoft.AspNetCore.Mvc;

namespace BKS.VacancyMagic.Backend.Controllers;

[Route("api/[controller]")]
public class VacancyController : Controller
{
    private readonly IVacancy _vacancyService;
    private readonly ISearch _searchService;
    private readonly AppDbContext _dbContext;
    private readonly ILogger _logger;
    public VacancyController(IVacancy vacancyService, ISearch searchService, AppDbContext dbContext, ILogger<VacancyController> logger)
    {
        _vacancyService = vacancyService;
        _searchService = searchService;
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// testMethod
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<SearchResponse>> GetChatSearch([FromQuery][FromBody]string prompt, CancellationToken ct)
    {
        var result = await _searchService.SearchAsync(prompt, ct);

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    [HttpGet("auth")]
    public async Task<ActionResult<AuthResultDTO>> Authorization(AuthRequestDTO req, CancellationToken ct)
    {
        var result = await _vacancyService.AuthorizationAsync(req, ct);

        try
        {
            await _dbContext.ServiceAuthorizations.AddAsync(new DAL.Models.ServiceAuthorization
            {
                AccessToken = result!.AccessToken!,
                RefreshToken = result.RefreshToken,
                ServiceId = 1,
                UserId = 1
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

    [HttpGet]
    public async Task<ActionResult<List<VacancyRecordDTO>?>> GetData(string prompt, CancellationToken ct)
    {
        var result = await _vacancyService.GetDataAsync(prompt, ct);

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
