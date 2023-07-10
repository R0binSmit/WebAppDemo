using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.VacationService.DataAccess.Entities;

namespace WebAppDemo.VacationService.DataAccess.EntityConfigurations;

internal class VacationConfiguration : IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        builder
            .HasKey(vacation => vacation.Id);

        builder
            .Property(vacation => vacation.Start)
            .IsRequired();

        builder
            .Property(vacation => vacation.End)
            .IsRequired();

        builder
            .HasOne(vacation => vacation.VacationType)
            .WithMany(vacationTypes => vacationTypes.Vacations)
            .HasForeignKey(vacation => vacation.VacationTypeId)
            .IsRequired();

        builder
            .HasOne(vacation => vacation.Employee)
            .WithMany(employee => employee.Vacations)
            .HasForeignKey(vacation => vacation.EmployeeId)
            .IsRequired();
    }
}
