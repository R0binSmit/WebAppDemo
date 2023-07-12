using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.VacationService.DataAccess.EntityConfigurations;

internal class AbsenceConfiguration : IEntityTypeConfiguration<Absence>
{
    public void Configure(EntityTypeBuilder<Absence> builder)
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
            .HasOne(vacation => vacation.AbsenceType)
            .WithMany(vacationTypes => vacationTypes.Absences)
            .HasForeignKey(vacation => vacation.AbsencseTypeId)
            .IsRequired();

        builder
            .HasOne(vacation => vacation.Employee)
            .WithMany(employee => employee.Vacations)
            .HasForeignKey(vacation => vacation.EmployeeId)
            .IsRequired();
    }
}
