using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Country;
using WebAppDemo.AbsenceService.IDataAccess;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository<Country> _countryRepository;
    private readonly ICountryMapper _countryMapper;
    
    public CountryController(ICountryRepository<Country> countryRepository, ICountryMapper countryMapper)
    {
        _countryRepository = countryRepository;
        _countryMapper = countryMapper;
    }

    /// <summary>
    /// Get specific country by id.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>Specific country.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetCountryDto>> GetCountryById(int id)
    {
        var country = await _countryRepository.GetAsync(id);
        return _countryMapper.Map(country);
    }

    /// <summary>
    /// Get all Countries from the repository.
    /// </summary>
    /// <returns>Json array of all Countries.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetCountryDto>>> GetCountries()
    {
        var countries = await _countryRepository.GetAllAsync();
        return _countryMapper.Map(countries);
    }
}
