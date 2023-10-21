using BKS.VacancyMagic.Backend.Interfaces;
using BKS.VacancyMagic.Backend.Models.Vacancy;
using Microsoft.AspNetCore.Mvc;

namespace BKS.VacancyMagic.Backend.Controllers;

[Route("api/[controller]")]
public class VacancyController : Controller
{
    private readonly IVacancy _vacancyService;
    public VacancyController(IVacancy vacancyService)
    {
        _vacancyService = vacancyService;
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
}
