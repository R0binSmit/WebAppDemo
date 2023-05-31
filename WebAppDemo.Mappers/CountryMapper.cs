using Riok.Mapperly.Abstractions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Country;
using WebAppDemo.IMappers;

namespace WebAppDemo.Mappers;

[Mapper]
public partial class CountryMapper : ICountryMapper
{
    public partial List<GetCountryDto> Map(List<Country> countries);
    public partial GetCountryDto Map(Country country);
    public partial Country Map(CreateCountryDto createCountryDto);
    public partial Country Map(UpdateCountryDto updateCountryDto);
}
