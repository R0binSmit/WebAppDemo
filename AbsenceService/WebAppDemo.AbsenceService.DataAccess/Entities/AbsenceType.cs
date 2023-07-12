namespace WebAppDemo.AbsenceService.DataAccess.Entities;

public class AbsenceType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Absence> Absences { get; set; } = default!;
}
