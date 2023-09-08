namespace WebAppDemo.AbsenceService.DataTransferObjects.State;

public class GetStateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DataAccess.Entities.Country Country { get; set; } = default!;
}
