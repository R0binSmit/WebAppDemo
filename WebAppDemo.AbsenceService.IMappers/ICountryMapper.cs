using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Country;

namespace WebAppDemo.AbsenceService.IMappers;

public interface ICountryMapper
{
    GetCountryDto Map(Country country);
    List<GetCountryDto> Map(List<Country> countries);
}
