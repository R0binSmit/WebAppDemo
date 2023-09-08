using Riok.Mapperly.Abstractions;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Employee;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Mappers;

[Mapper]
public partial class EmployeeMapper : IEmployeeMapper
{
    public partial GetEmployeeDto Map(Employee employee);
    public partial List<GetEmployeeDto> Map(List<Employee> employees);

}
