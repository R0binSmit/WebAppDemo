namespace WebAppDemo.AbsenceService.DataTransferObjects.Country;

public class GetCountryDto
{
    public int Id { get; set; }
    public string ShortName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
}
