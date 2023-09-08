namespace WebAppDemo.AbsenceService.DataTransferObjects.Absence;

public class GetAbsenceDto
{
    public int Id { get; set; }
    public DataAccess.Entities.AbsenceType AbsenceType { get; set; } = default!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DataAccess.Entities.Employee Employee { get; set; } = default!;
}
