using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Address;

namespace WebAppDemo.IMappers;

public interface IAddressMapper
{
    List<GetAddressDto> Map(List<Address> addresses);
    GetAddressDto Map(Address address);
    Address Map(CreateAddressDto createAddressDto);
    Address Map(UpdateAddressDto updateAddressDto);
}
