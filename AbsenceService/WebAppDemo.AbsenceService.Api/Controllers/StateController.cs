using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.State;
using WebAppDemo.AbsenceService.IDataAccess;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateRepository<State> _stateRepository;
    private readonly IStateMapper _stateMapper;

    public StateController(IStateRepository<State> stateRepository, IStateMapper stateMapper)
    {
        _stateRepository = stateRepository;
        _stateMapper = stateMapper;
    }

    /// <summary>
    /// Get specific state by id.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>Specific state</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetStateDto>> GetStateById(int id)
    {
        var state = await _stateRepository.GetAsync(id);
        return _stateMapper.Map(state);
    }

    /// <summary>
    /// Get all States from the Repository.
    /// </summary>
    /// <returns>Json array of all States.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetStateDto>>> GetStates()
    {
        var states = await _stateRepository.GetAllAsync();
        return _stateMapper.Map(states);
    }
}
