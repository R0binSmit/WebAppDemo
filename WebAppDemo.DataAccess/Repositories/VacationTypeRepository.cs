using WebAppDemo.DataAccess;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.IBusinessLogic.Interfaces.Repositories;

namespace WebAppDemo.BusinessLogic.Repositories;

public class VacationTypeRepository : GenericRepository<VacationType>, IVacationTypeRepository<VacationType>
{
    public VacationTypeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
