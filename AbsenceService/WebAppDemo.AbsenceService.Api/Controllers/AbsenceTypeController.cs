using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AbsenceTypeController : ControllerBase
{
    private readonly IAbsenceTypeRepository<AbsenceType> _absenceTypeRepository;

    public AbsenceTypeController(IAbsenceTypeRepository<AbsenceType> absenceTypeRepository)
    {
        _absenceTypeRepository = absenceTypeRepository;
    }

    /// <summary>
    /// Get all AbsenceTypes from the repository.
    /// </summary>
    /// <returns>Json array of all AbsenceTypes.</returns>
    [HttpGet]
    public async Task<ActionResult<List<AbsenceType>>> GetAbsenceTypes()
    {
        return await _absenceTypeRepository.GetAllAsync();
    }
}
