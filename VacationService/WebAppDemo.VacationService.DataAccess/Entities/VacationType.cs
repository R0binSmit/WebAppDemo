namespace WebAppDemo.VacationService.DataAccess.Entities;

public class VacationType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Vacation> Vacations { get; set; } = default!;
}
