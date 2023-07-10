using WebAppDemo.IGeneric;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.IDataAccess;

namespace WebAppDemo.VacationService.DataAccess.Repositories;

public class StateRepository : GenericRepository<State>, IStateRepository<State>
{
    public StateRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
