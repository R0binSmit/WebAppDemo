namespace WebAppDemo.VacationService.DataAccess.Entities;

public class Country
{
    public int Id { get; set; }
    public string ShortName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public List<State> States { get; set; } = default!;
}
