using WebAppDemo.BusinessLogic.Repositories;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.IDataAccess.Repositories;

namespace WebAppDemo.DataAccess.Repositories;

public class CountryRepository : GenericRepository<Country>, ICountryRepoitory<Country>
{
    public CountryRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
