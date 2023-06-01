using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Api.Exceptions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Country;
using WebAppDemo.IDataAccess.Repositories;
using WebAppDemo.IMappers;

namespace WebAppDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepoitory<Country> _countryRepoitory;
    private readonly ICountryMapper _countryMapper;

    public CountriesController(
        ICountryRepoitory<Country> countryRepoitory,
        ICountryMapper countryMapper)
    {
        _countryRepoitory = countryRepoitory;
        _countryMapper = countryMapper;
    }

    /// <summary>
    /// Gets a list of countries from the repository.
    /// </summary>
    /// <returns>A list of countries.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetCountryDto>>> GetCountries()
    {
        var countries = await _countryRepoitory.GetAllAsync();
        return _countryMapper.Map(countries);
    }

    /// <summary>
    /// Gets a Country by its id.
    /// </summary>
    /// <param name="id">The id of the Country to get.</param>
    /// <returns>The Country with the given id.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetCountryDto>> GetCountry(int id)
    {
        var country = await _countryRepoitory.GetAsync(id);

        if (country == null)
        {
            throw new NotFoundException($"There is no Country with the given id ({id}).");
        }

        return _countryMapper.Map(country);
    }

    [HttpPost]
    public async Task<ActionResult<GetCountryDto>> CreateCountry(CreateCountryDto createCountryDto)
    {
        var country = _countryMapper.Map(createCountryDto);
        await _countryRepoitory.AddAsync(country);

        var newCountry = await _countryRepoitory.GetAsync(country.Id);

        if (newCountry == null)
        {
            throw new NotFoundException("Can't found the new created country.");
        }

        return _countryMapper.Map(newCountry);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCountry(UpdateCountryDto updateCountryDto)
    {
        var country = _countryMapper.Map(updateCountryDto);
        var countryExists = await _countryRepoitory.ExistsAsync(country.Id);

        if (countryExists == false)
        {
            throw new NotFoundException($"Can't update country because there is no country with the given id ({country.Id}).");
        }

        await _countryRepoitory.UpdateAsync(country);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCountry(int id)
    {
        var country = await _countryRepoitory.GetAsync(id);

        if (country == null)
        {
            throw new NotFoundException($"Can't delete country because there is no country with the given id ({id}).");
        }

        await _countryRepoitory.DeleteAsync(id);
        return NoContent();
    }
}
