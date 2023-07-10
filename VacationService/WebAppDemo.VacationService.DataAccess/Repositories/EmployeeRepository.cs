using WebAppDemo.IGeneric;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.IDataAccess;

namespace WebAppDemo.VacationService.DataAccess.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository<Employee>
{
    public EmployeeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
