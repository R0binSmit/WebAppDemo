using Microsoft.EntityFrameworkCore;
using WebAppDemo.VacationService.DataAccess.Entities;
using WebAppDemo.VacationService.DataAccess.EntityConfigurations;

namespace WebAppDemo.VacationService.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<State> States => Set<State>();
    public DbSet<Vacation> Vacations => Set<Vacation>();
    public DbSet<VacationType> VacationTypes => Set<VacationType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Entities.
        new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
        new CountryConfiguration().Configure(modelBuilder.Entity<Country>());
        new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());
        new StateConfiguration().Configure(modelBuilder.Entity<State>());
        new VacationConfiguration().Configure(modelBuilder.Entity<Vacation>());
        new VacationTypeConfiguration().Configure(modelBuilder.Entity<VacationType>());
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
