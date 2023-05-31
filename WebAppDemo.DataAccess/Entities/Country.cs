namespace WebAppDemo.DataAccess.Entities;

public class Country
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public virtual List<State> States { get; set; } = default!;
}
