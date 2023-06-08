using Microsoft.EntityFrameworkCore;
using WebAppDemo.BusinessLogic.Repositories;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.IDataAccess.Repositories;

namespace WebAppDemo.DataAccess.Repositories;

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
            .ToListAsync();
    }

    public async override Task<State?> GetAsync(int id)
    {
        return await _context
            .Set<State>()
            .Include(state => state.Country)
            .FirstOrDefaultAsync(address => address.Id == id);
    }

    public async Task<bool> IsNameAward(string name)
    {
        var state = await _context
            .Set<State>()
            .FirstOrDefaultAsync(state => state.Name == name);

        return !(state == null);
    }

    public async Task<List<State>> GetStatesByCountryId(int countryId)
    {
        return await _context
            .Set<State>()
            .Where(state => countryId == state.CountryId)
            .Include(state => state.Country)
            .ToListAsync();
    }
}
