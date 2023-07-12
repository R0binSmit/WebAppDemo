namespace WebAppDemo.AbsenceService.DataAccess.Entities;

public class Absence
{
    public int Id { get; set; }
    public int AbsencseTypeId { get; set; }
    public AbsenceType AbsenceType { get; set; } = default!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;
}
