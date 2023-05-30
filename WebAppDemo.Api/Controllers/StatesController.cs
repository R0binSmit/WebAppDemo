using Microsoft.AspNetCore.Mvc;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.State;
using WebAppDemo.IDataAccess.Repositories;
using WebAppDemo.IMappers;

namespace WebAppDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatesController : ControllerBase
{
    private readonly IStateRepository<State> _stateRepository;
    private readonly IStateMapper _stateMapper;

    public StatesController(
        IStateRepository<State> stateRepository,
        IStateMapper stateMapper)
    {
        _stateRepository = stateRepository;
        _stateMapper = stateMapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetStateDto>>> GetStates()
    {
        var states = await _stateRepository.GetAllAsync();
        return _stateMapper.Map(states);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetStateDto>> GetState(int id)
    {
        var state = await _stateRepository.GetAsync(id);

        if (state == null)
        {
            return NotFound();
        }

        return _stateMapper.Map(state);
    }

    [HttpPost]
    public async Task<ActionResult<GetStateDto>> CreateState(CreateStateDto createStateDto)
    {
        var state = _stateMapper.Map(createStateDto);
        await _stateRepository.AddAsync(state);
        return CreatedAtAction("GetState", new { id = state.Id }, _stateMapper.Map(state));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateState(UpdateStateDto updateStateDto)
    {
        var state = _stateMapper.Map(updateStateDto);
        var stateExist = await _stateRepository.ExistsAsync(updateStateDto.Id);

        if(updateStateDto.Id != state.Id || stateExist == false)
        {
            return BadRequest();
        }

        await _stateRepository.UpdateAsync(state);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteState(int id)
    {
        var state = await _stateRepository.GetAsync(id);

        if (state == null)
        {
            return NotFound();
        }

        await _stateRepository.DeleteAsync(state.Id);
        return NoContent();
    }
}
