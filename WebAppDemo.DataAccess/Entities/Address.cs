namespace WebAppDemo.DataAccess.Entities;

public class Address
{
    public int Id { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int HouseNumber { get; set; }
    public string HouseNumberAddition { get; set; } = string.Empty;
    public int StateId { get; set; }
    public State State { get; set; } = default!;

}
