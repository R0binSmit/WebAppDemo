using WebAppDemo.IGeneric;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.IDataAccess;

namespace WebAppDemo.VacationService.DataAccess.Repositories;

public class CountryRepository : GenericRepository<Country>, ICountryRepository<Country>
{
    public CountryRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
