using WebAppDemo.IGeneric;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.IDataAccess;

namespace WebAppDemo.VacationService.DataAccess.Repositories;

public class VacationTypeRepository : GenericRepository<VacationType>, IVacationTypeRepository<VacationType>
{
    public VacationTypeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
