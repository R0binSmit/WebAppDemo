using WebAppDemo.DataTransferObjects.State;

namespace WebAppDemo.DataTransferObjects.Address;

public class GetAddressDto
{
    public int Id { get; set; }
    public GetStateDto State { get; set; } = default!;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int HouseNumber { get; set; }
    public string HouseNumberAddition { get; set; } = string.Empty;
}
