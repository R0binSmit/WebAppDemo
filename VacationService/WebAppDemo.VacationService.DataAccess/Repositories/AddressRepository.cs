using WebAppDemo.IGeneric;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.IDataAccess;

namespace WebAppDemo.VacationService.DataAccess.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository<Address>
{
    public AddressRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
