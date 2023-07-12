using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.DataAccess.Repositories;

public class AbsenceRepository : GenericRepository<Absence>, IAbsenceRepository<Absence>
{
    public AbsenceRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
