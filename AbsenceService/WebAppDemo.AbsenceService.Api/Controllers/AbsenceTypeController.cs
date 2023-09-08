using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.AbsenceType;
using WebAppDemo.AbsenceService.IDataAccess;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AbsenceTypeController : ControllerBase
{
    private readonly IAbsenceTypeRepository<AbsenceType> _absenceTypeRepository;
    private readonly IAbsenceTypeMapper _absenceTypeMapper;

    public AbsenceTypeController(IAbsenceTypeRepository<AbsenceType> absenceTypeRepository, IAbsenceTypeMapper absenceTypeMapper)
    {
        _absenceTypeRepository = absenceTypeRepository;
        _absenceTypeMapper = absenceTypeMapper;
    }

    /// <summary>
    /// Get specific absenceType by id.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>Specific absenceType</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetAbsenceTypeDto>> GetAbsenceTypeById(int id)
    {
        var absenceType = await _absenceTypeRepository.GetAsync(id);
        return _absenceTypeMapper.Map(absenceType);
    }

    /// <summary>
    /// Get all AbsenceTypes from the repository.
    /// </summary>
    /// <returns>Json array of all AbsenceTypes.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetAbsenceTypeDto>>> GetAbsenceTypes()
    {
        var absenceTypes = await _absenceTypeRepository.GetAllAsync();
        return _absenceTypeMapper.Map(absenceTypes);
    }
}
