using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Search;
using BKS.VacancyMagic.Backend.Models.Vacancy;
using Microsoft.AspNetCore.Mvc;

namespace BKS.VacancyMagic.Backend.Controllers;

[Route("api/[controller]")]
public class VacancyController : Controller
{
    private readonly IVacancy _vacancyService;
    private readonly ISearch _searchService;
    public VacancyController(IVacancy vacancyService, ISearch searchService)
    {
        _vacancyService = vacancyService;
        _searchService = searchService;
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

    [HttpGet]
    public async Task<ActionResult<List<VacancyRecordDTO>?>> GetData(string prompt)
    {
        var result = await _vacancyService.GetDataAsync(prompt);

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }
    [HttpPost]
    public async Task<ActionResult<List<VacancyRecordDTO>?>> ReplyVacancy(VacancyRecordDTO vacancy, CancellationToken ct)
    {
        var result = await _vacancyService.ReplyAsync(vacancy);

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }
}
