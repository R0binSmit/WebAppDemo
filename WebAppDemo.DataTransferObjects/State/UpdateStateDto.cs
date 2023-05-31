namespace WebAppDemo.DataTransferObjects.State;

public class UpdateStateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CountryId { get; set; }
}
