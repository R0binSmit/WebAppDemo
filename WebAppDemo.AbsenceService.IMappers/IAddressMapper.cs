using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Address;

namespace WebAppDemo.AbsenceService.IMappers;

public interface IAddressMapper
{
    GetAddressDto Map(Address address);
    List<GetAddressDto> Map(List<Address> addresses);
}
