using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.DataAccess.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository<Address>
{
    public AddressRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
