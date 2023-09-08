using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Absence;
using WebAppDemo.AbsenceService.IDataAccess;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AbsenceController : ControllerBase
{
    private readonly IAbsenceRepository<Absence> _absenceRepository;
    private readonly IAbsenceMapper _absenceMapper;

    public AbsenceController(IAbsenceRepository<Absence> absenceRepository, IAbsenceMapper absenceMapper)
    {
        _absenceRepository = absenceRepository;
        _absenceMapper = absenceMapper;
    }

    /// <summary>
    /// Get specific absence by id.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>Specific absence.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetAbsenceDto>> GetAbsenceById(int id)
    {
        var absence = await _absenceRepository.GetAsync(id);
        return _absenceMapper.Map(absence);
    }

    /// <summary>
    /// Get all Absences from the Repository.
    /// </summary>
    /// <returns>Json array of all Absences.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetAbsenceDto>>> GetAbsences()
    {
        var absences = await _absenceRepository.GetAllAsync();
        return _absenceMapper.Map(absences);
    }
}
