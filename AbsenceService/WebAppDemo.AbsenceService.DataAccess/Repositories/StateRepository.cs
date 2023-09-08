using Microsoft.EntityFrameworkCore;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.DataAccess.Repositories;

public class StateRepository : GenericRepository<State>, IStateRepository<State>
{
    public StateRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async override Task<List<State>> GetAllAsync()
    {
        return await _context
            .Set<State>()
            .Include(state => state.Country)
            .ToListAsync()
        ;
    }
}
