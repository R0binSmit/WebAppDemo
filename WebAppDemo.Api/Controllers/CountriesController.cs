using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

    [HttpGet]
    public async Task<ActionResult<List<GetCountryDto>>> GetCountries()
    {
        var countries = await _countryRepoitory.GetAllAsync();
        return _countryMapper.Map(countries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCountryDto>> GetCountry(int id)
    {
        var country = await _countryRepoitory.GetAsync(id);

        if(country == null)
        {
            return NotFound();
        }

        return _countryMapper.Map(country);
    }

    [HttpPost]
    public async Task<ActionResult<GetCountryDto>> CreateCountry(CreateCountryDto createCountryDto)
    {
        var country = _countryMapper.Map(createCountryDto);
        await _countryRepoitory.AddAsync(country);
        return CreatedAtAction("GetCountry", new { id = country.Id }, _countryMapper.Map(country));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCountry(UpdateCountryDto updateCountryDto)
    {
        var country = _countryMapper.Map(updateCountryDto);
        var countryExists = await _countryRepoitory.ExistsAsync(country.Id);

        if(updateCountryDto.Id != country.Id || countryExists == false)
        {
            return BadRequest();
        }

        await _countryRepoitory.UpdateAsync(country);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCountry(int id)
    {
        var country = await _countryRepoitory.GetAsync(id);

        if(country == null)
        {
            return NotFound();
        }

        await _countryRepoitory.DeleteAsync(id);
        return NoContent();
    }
}
