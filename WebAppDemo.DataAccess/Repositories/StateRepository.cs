using WebAppDemo.BusinessLogic.Repositories;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.IDataAccess.Repositories;

namespace WebAppDemo.DataAccess.Repositories;

public class StateRepository : GenericRepository<State>, IStateRepository<State>
{
    public StateRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
