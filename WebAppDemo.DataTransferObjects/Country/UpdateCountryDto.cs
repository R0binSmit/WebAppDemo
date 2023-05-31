namespace WebAppDemo.DataTransferObjects.Country;

public class UpdateCountryDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
}
