using Microsoft.EntityFrameworkCore;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.VacationService.DataAccess.EntityConfigurations;

namespace WebAppDemo.AbsenceService.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<State> States => Set<State>();
    public DbSet<Absence> Vacations => Set<Absence>();
    public DbSet<AbsenceType> VacationTypes => Set<AbsenceType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Entities.
        new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
        new CountryConfiguration().Configure(modelBuilder.Entity<Country>());
        new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());
        new StateConfiguration().Configure(modelBuilder.Entity<State>());
        new AbsenceConfiguration().Configure(modelBuilder.Entity<Absence>());
        new AbsenceTypeConfiguration().Configure(modelBuilder.Entity<AbsenceType>());
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
