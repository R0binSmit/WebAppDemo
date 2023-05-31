using Riok.Mapperly.Abstractions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Address;
using WebAppDemo.IMappers;

namespace WebAppDemo.Mappers;

[Mapper]
public partial class AddressMapper : IAddressMapper
{
    public partial List<GetAddressDto> Map(List<Address> addresses);
    public partial GetAddressDto Map(Address address);
    public partial Address Map(CreateAddressDto createAddressDto);
    public partial Address Map(UpdateAddressDto updateAddressDto);

}
