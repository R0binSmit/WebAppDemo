using WebAppDemo.IGeneric;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.IDataAccess;

namespace WebAppDemo.VacationService.DataAccess.Repositories;

public class VacationRepository : GenericRepository<Vacation>, IVacationRepository<Vacation>
{
    public VacationRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
