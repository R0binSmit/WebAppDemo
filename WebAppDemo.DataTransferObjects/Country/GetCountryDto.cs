using WebAppDemo.DataTransferObjects.State;

namespace WebAppDemo.DataTransferObjects.Country;

public class GetCountryDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
}
