namespace WebAppDemo.AbsenceService.DataTransferObjects.Employee;

public class GetEmployeeDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DataAccess.Entities.Address Address { get; set; } = default!;
}
