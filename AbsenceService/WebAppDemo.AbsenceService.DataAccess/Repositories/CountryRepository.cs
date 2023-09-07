using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.DataAccess.Repositories;

public class CountryRepository : GenericRepository<Country>, ICountryRepository<Country>
{
    public CountryRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
