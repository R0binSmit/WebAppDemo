using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository<Country> _countryRepository;
    
    public CountryController(ICountryRepository<Country> countryRepository)
    {
        _countryRepository = countryRepository;
    }

    /// <summary>
    /// Get all Countries from the repository.
    /// </summary>
    /// <returns>Json array of all Countries.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Country>>> GetCountries()
    {
        return await _countryRepository.GetAllAsync();
    }
}
