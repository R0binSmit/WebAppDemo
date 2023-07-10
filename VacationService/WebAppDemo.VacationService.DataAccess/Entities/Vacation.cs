namespace WebAppDemo.VacationService.DataAccess.Entities;

public class Vacation
{
    public int Id { get; set; }
    public int VacationTypeId { get; set; }
    public VacationType VacationType { get; set; } = default!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;
}
