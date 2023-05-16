using WebAppDemo.BusinessLogic.Interfaces.Repositories;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataAccess;

namespace WebAppDemo.BusinessLogic.Repositories;

public class VacationTypeRepository : GenericRepository<VacationType>, IVacationTypeRepository
{
    public VacationTypeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
