using Riok.Mapperly.Abstractions;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Country;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Mappers;

[Mapper]
public partial class CountryMapper : ICountryMapper
{
    public partial GetCountryDto Map(Country country);
    public partial List<GetCountryDto> Map(List<Country> countryList);
}
