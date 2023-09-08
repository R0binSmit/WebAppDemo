using Riok.Mapperly.Abstractions;
using WebAppDemo.AbsenceService.IMappers;
using WebAppDemo.AbsenceService.DataTransferObjects.Address;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.AbsenceService.Mappers;

[Mapper]
public partial class AddressMapper : IAddressMapper
{
    public partial GetAddressDto Map(Address address);
    public partial List<GetAddressDto> Map(List<Address> addresses);
}
