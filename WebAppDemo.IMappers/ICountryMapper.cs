using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Country;

namespace WebAppDemo.IMappers;

public interface ICountryMapper
{
    List<GetCountryDto> Map(List<Country> countries);
    GetCountryDto Map(Country country);
    Country Map(CreateCountryDto createCountryDto);
    Country Map(UpdateCountryDto updateCountryDto);
}
