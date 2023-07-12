using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.VacationService.DataAccess.EntityConfigurations;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasKey(employee => employee.Id);

        builder
            .Property(employee => employee.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(employee => employee.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasOne(employee => employee.Address)
            .WithMany(address => address.Employees)
            .HasForeignKey(employee => employee.AddressId)
            .IsRequired();

        builder
            .HasMany(employee => employee.Vacations)
            .WithOne(vacation => vacation.Employee)
            .HasForeignKey(vacation => vacation.EmployeeId);
    }
}
