using Microsoft.EntityFrameworkCore;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataAccess.EntityConfigurations;

namespace WebAppDemo.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<VacationType> VacationTypes => Set<VacationType>();
    public DbSet<State> Statements => Set<State>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Entities.
        new VacationTypeConfiguration().Configure(modelBuilder.Entity<VacationType>());
        new StateConfiguration().Configure(modelBuilder.Entity<State>());
        new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
        new CountryConfiguration().Configure(modelBuilder.Entity<Country>());
    }
}
