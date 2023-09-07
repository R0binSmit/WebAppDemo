using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AbsenceController : ControllerBase
{
    private readonly IAbsenceRepository<Absence> _absenceRepository;

    public AbsenceController(IAbsenceRepository<Absence> absenceRepository)
    {
        _absenceRepository = absenceRepository;
    }

    /// <summary>
    /// Get all Absences from the Repository.
    /// </summary>
    /// <returns>Json array of all Absences.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Absence>>> GetAbsences()
    {
        return await _absenceRepository.GetAllAsync();
    }
}
