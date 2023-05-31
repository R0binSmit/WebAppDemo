using WebAppDemo.DataTransferObjects.Country;

namespace WebAppDemo.DataTransferObjects.State;

public class GetStateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public GetCountryDto Country { get; set; } = default!;
}
