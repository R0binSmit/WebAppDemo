using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Employee;

namespace WebAppDemo.AbsenceService.IMappers;

public interface IEmployeeMapper
{
    GetEmployeeDto Map(Employee employee);
    List<GetEmployeeDto> Map(List<Employee> employees);
}
