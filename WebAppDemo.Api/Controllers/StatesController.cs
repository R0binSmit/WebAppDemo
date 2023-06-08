using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Api.Exceptions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Country;
using WebAppDemo.DataTransferObjects.State;
using WebAppDemo.IDataAccess.Repositories;
using WebAppDemo.IMappers;

namespace WebAppDemo.Api.Controllers;

/// <summary>
/// Controller for managing states.
/// </summary>
/// <returns>Actions for getting, creating, updating and deleting states.</returns>
[Route("api/[controller]")]
[ApiController]
public class StatesController : ControllerBase
{
    private readonly IStateRepository<State> _stateRepository;
    private readonly ICountryRepoitory<Country> _countryRepoitory;
    private readonly IStateMapper _stateMapper;

    public StatesController(
        IStateRepository<State> stateRepository,
        ICountryRepoitory<Country> countryRepoitory,
        IStateMapper stateMapper)
    {
        _stateRepository = stateRepository;
        _countryRepoitory = countryRepoitory;
        _stateMapper = stateMapper;
    }

    /// <summary>
    /// Gets a list of states from the repository.
    /// </summary>
    /// <returns>A list of GetStateDto objects.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetStateDto>>> GetStates()
    {
        var states = await _stateRepository.GetAllAsync();
        return _stateMapper.Map(states);
    }

    /// <summary>
    /// Gets a state by its id.
    /// </summary>
    /// <param name="id">The id of the state.</param>
    /// <returns>The state with the given id.</returns>
    [HttpGet("GetByStateId/{stateId}")]
    public async Task<ActionResult<GetStateDto>> GetState(int id)
    {
        var state = await _stateRepository.GetAsync(id);

        if (state == null)
        {
            throw new NotFoundException($"Can't find State by given id ({id}).");
        }

        return _stateMapper.Map(state);
    }

    [HttpGet("GetByCountryId/{countryId}")]
    public async Task<ActionResult<List<GetStateDto>>> GetStatesByCountryId(int countryId)
    {
        var states = await _stateRepository.GetStatesByCountryId(countryId);
        return _stateMapper.Map(states);
    }

    /// <summary>
    /// Creates a new state with the given data.
    /// </summary>
    /// <param name="createStateDto">The data for the new state.</param>
    /// <returns>The created state.</returns>
    [HttpPost]
    public async Task<ActionResult<GetStateDto>> CreateState(CreateStateDto createStateDto)
    {
        var state = _stateMapper.Map(createStateDto);
        var isNameAward = await _stateRepository.IsNameAward(state.Name);
        var countryExists = await _countryRepoitory.ExistsAsync(state.CountryId);

        if (isNameAward == true)
        {
            throw new ArgumentException(
                $"Can't create State because a State with the given name ({state.Name}) already exists.",
                nameof(createStateDto.Name)
            );
        }

        if (countryExists == false)
        {
            throw new ArgumentException(
                $"Can't create State because the given countryId ({state.CountryId}) does not exists.",
                nameof(createStateDto.CountryId)
            );
        }

        await _stateRepository.AddAsync(state);
        var newState = await _stateRepository.GetAsync(state.Id);

        if (newState == null)
        {
            throw new NotFoundException("Can't found the new created state.");
        }

        return _stateMapper.Map(newState);
    }


    /// <summary>
    /// Updates a state with the given data.
    /// </summary>
    /// <param name="updateStateDto">The data to update the state with.</param>
    /// <returns>An Ok result if the update was successful.</returns>
    [HttpPut]
    public async Task<ActionResult> UpdateState(UpdateStateDto updateStateDto)
    {
        var state = _stateMapper.Map(updateStateDto);
        var stateExist = await _stateRepository.ExistsAsync(state.Id);
        var isNameAward = await _stateRepository.IsNameAward(state.Name);
        var countryExists = await _countryRepoitory.ExistsAsync(state.CountryId);

        if (stateExist == false)
        {
            throw new NotFoundException($"Can't update State because there is no State with the given id ({state.Id}).");
        }

        if (isNameAward == true)
        {
            throw new ArgumentException(
                $"Can't update State because a State with the given name ({state.Name}) already exists.",
                nameof(state.Name)
            );
        }

        if (!countryExists)
        {
            throw new ArgumentException(
                $"Can't update State because the given countryId ({state.CountryId}) does not exists.",
                nameof(state.CountryId)
            );
        }

        await _stateRepository.UpdateAsync(state);
        return Ok();
    }

    /// <summary>
    /// Deletes a state from the database.
    /// </summary>
    /// <param name="id">The id of the state to delete.</param>
    /// <returns>No content if the state was successfully deleted.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteState(int id)
    {
        var state = await _stateRepository.GetAsync(id);

        if (state == null)
        {
            throw new NotFoundException($"Can't delete State because there is no State with the given id ({id}).");
        }

        await _stateRepository.DeleteAsync(state.Id);
        return NoContent();
    }
}
