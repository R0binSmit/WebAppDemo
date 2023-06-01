using Microsoft.EntityFrameworkCore;
using WebAppDemo.BusinessLogic.Repositories;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.IDataAccess.Repositories;

namespace WebAppDemo.DataAccess.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository<Address>
{
    public AddressRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
       
    }

    public async override Task<List<Address>> GetAllAsync()
    {
        return await _context
            .Set<Address>()
            .Include(address => address.State)
            .Include(address => address.State.Country)
            .ToListAsync();
    }

    public async override Task<Address?> GetAsync(int id)
    {
        return await _context
            .Set<Address>()
            .Include(address => address.State)
            .Include(address => address.State.Country)
            .FirstOrDefaultAsync(address => address.Id == id);
    }
}
