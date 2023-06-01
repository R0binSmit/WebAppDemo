using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Api.Exceptions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.VacationType;
using WebAppDemo.IBusinessLogic.Interfaces.Repositories;
using WebAppDemo.IMappers;

namespace WebAppDemo.Api.Controllers;

/// <summary>
/// Controller for managing VacationType objects.
/// </summary>
/// <returns>
/// Actions for getting, creating, updating and deleting VacationType objects.
/// </returns>
[Route("api/[controller]")]
[ApiController]
public class VacationTypesController : ControllerBase
{
    private readonly IVacationTypeRepository<VacationType> _vacationTypeRepository;
    private readonly IVacationTypeMapper _vacationTypeMapper;

    public VacationTypesController(
        IVacationTypeRepository<VacationType> vacationTypeRepository,
        IVacationTypeMapper vacationTypeMapper)
    {
        _vacationTypeRepository = vacationTypeRepository;
        _vacationTypeMapper = vacationTypeMapper;
    }

    /// <summary>
    /// Gets all vacation types from the repository and maps them to GetVacationTypeDto objects.
    /// </summary>
    /// <returns>A list of GetVacationTypeDto objects.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetVacationTypeDto>>> GetVacationTypes()
    {
        var vacationTypes = await _vacationTypeRepository.GetAllAsync();
        return _vacationTypeMapper.Map(vacationTypes);
    }

    /// <summary>
    /// Gets VacationType by given id.
    /// </summary>
    /// <param name="id">VacationType id.</param>
    /// <returns>VacationType object.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetVacationTypeDto>> GetVacationType(int id)
    {
        var vacationType = await _vacationTypeRepository.GetAsync(id);

        if (vacationType == null)
        {
            throw new NotFoundException($"Can't find VacationType by given id ({id}).");
        }

        return _vacationTypeMapper.Map(vacationType);
    }

    /// <summary>
    /// Creates a new vacation type.
    /// </summary>
    /// <param name="createVacationTypeDto">The data transfer object for creating a new vacation type.</param>
    /// <returns>The newly created vacation type.</returns>
    [HttpPost]
    public async Task<ActionResult<GetVacationTypeDto>> CreateVacationType(CreateVacationTypeDto createVacationTypeDto)
    {
        var vacationType = _vacationTypeMapper.Map(createVacationTypeDto);
        await _vacationTypeRepository.AddAsync(vacationType);
        var newVacationType = await _vacationTypeRepository.GetAsync(vacationType.Id);

        if (newVacationType == null)
        {
            throw new NotFoundException($"Can't finde created VacationType by id ({vacationType.Id}).");
        }

        return _vacationTypeMapper.Map(newVacationType);
    }

    /// <summary>
    /// Updates a VacationType with the given id.
    /// </summary>
    /// <param name="updateVacationTypeDto">The VacationType to update.</param>
    /// <returns>
    /// An Ok result if the VacationType was updated successfully.
    /// </returns>
    [HttpPut]
    public async Task<ActionResult> UpdateVacationType(UpdateVacationTypeDto updateVacationTypeDto)
    {
        var vacationType = _vacationTypeMapper.Map(updateVacationTypeDto);
        var vacationTypeExists = await _vacationTypeRepository.ExistsAsync(vacationType.Id);

        if (vacationTypeExists == false)
        {
            throw new NotFoundException($"Can't update VacationType because there is VacationType with the given id ({vacationType.Id}).");
        }

        await _vacationTypeRepository.UpdateAsync(vacationType);
        return Ok();
    }

    /// <summary>
    /// Deletes a vacation type with the specified id.
    /// </summary>
    /// <param name="id">The id of the vacation type to delete.</param>
    /// <returns>A 204 No Content response if the vacation type was deleted successfully.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVacationType(int id)
    {
        var vacationType = await _vacationTypeRepository.GetAsync(id);

        if (vacationType == null)
        {
            throw new NotFoundException($"Can't delete VacationType because there is no VacationType with the given id ({id}).");
        }

        await _vacationTypeRepository.DeleteAsync(id);
        return NoContent();
    }
}
