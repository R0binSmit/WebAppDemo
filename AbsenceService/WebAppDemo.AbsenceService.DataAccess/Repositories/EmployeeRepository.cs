using WebAppDemo.IGeneric;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.DataAccess.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository<Employee>
{
    public EmployeeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
