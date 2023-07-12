using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.DataAccess.Repositories;

public class AbsenceTypeRepository : GenericRepository<AbsenceType>, IAbsenceTypeRepository<AbsenceType>
{
    public AbsenceTypeRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
