using Microsoft.AspNetCore.Mvc;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.VacationType;
using WebAppDemo.IBusinessLogic.Interfaces.Repositories;
using WebAppDemo.IMappers;

namespace WebAppDemo.Api.Controllers;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetVacationTypeDto>>> GetVacationTypes()
    {
        var vacationTypes = await _vacationTypeRepository.GetAllAsync();
        return _vacationTypeMapper.Map(vacationTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetVacationTypeDto>> GetVacationType(int id)
    {
        var vacationType = await _vacationTypeRepository.GetAsync(id);

        if(vacationType == null)
        {
            return NotFound();
        }

        return _vacationTypeMapper.Map(vacationType);
    }

    [HttpPost]
    public async Task<ActionResult<GetVacationTypeDto>> CreateVacationType(CreateVacationTypeDto createVacationTypeDto)
    {
        var vacationType = _vacationTypeMapper.Map(createVacationTypeDto);
        await _vacationTypeRepository.AddAsync(vacationType);
        return CreatedAtAction("GetVacationType", new { id = vacationType.Id }, _vacationTypeMapper.Map(vacationType));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateVacationType(UpdateVacationTypeDto updateVacationTypeDto)
    {
        var vacationType = _vacationTypeMapper.Map(updateVacationTypeDto);
        var vacationTypeExists = await _vacationTypeRepository.ExistsAsync(vacationType.Id);

        if (updateVacationTypeDto.Id != vacationType.Id || vacationTypeExists == false)
        {
            return BadRequest();
        }

        await _vacationTypeRepository.UpdateAsync(vacationType);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVacationType(int id)
    {
        var vacationType = await _vacationTypeRepository.GetAsync(id);

        if (vacationType == null)
        {
            return NotFound();
        }

        await _vacationTypeRepository.DeleteAsync(id);
        return NoContent();
    }
}
