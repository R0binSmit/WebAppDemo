namespace WebAppDemo.DataTransferObjects.Address;

public class CreateAddressDto
{
    public int StateId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int HouseNumber { get; set; }
    public string HouseNumberAddition { get; set; } = string.Empty;
}
