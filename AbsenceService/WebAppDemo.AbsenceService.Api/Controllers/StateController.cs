using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateRepository<State> _stateRepository;

    public StateController(IStateRepository<State> stateRepository)
    {
        _stateRepository = stateRepository;
    }

    /// <summary>
    /// Get all States from the Repository.
    /// </summary>
    /// <returns>Json array of all States.</returns>
    [HttpGet]
    public async Task<ActionResult<List<State>>> GetStates()
    {
        return await _stateRepository.GetAllAsync();
    }
}
