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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Entities.
        new VacationTypeConfiguration().Configure(modelBuilder.Entity<VacationType>());
        new StateConfiguration().Configure(modelBuilder.Entity<State>());
    }
}
