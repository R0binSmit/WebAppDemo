using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.AbsenceService.DataAccess.EntityConfiguration;

public class AbsenceConfiguration : IEntityTypeConfiguration<Absence>
{
    public void Configure(EntityTypeBuilder<Absence> builder)
    {
        builder
            .HasKey(absenceType => absenceType.Id);

        builder
            .Property(absenceType => absenceType.Start)
            .IsRequired();

        builder
            .Property(absenceType => absenceType.End)
            .IsRequired();

        builder
            .HasOne(absenceType => absenceType.AbsenceType)
            .WithMany(absenceType => absenceType.Absences)
            .HasForeignKey(absence => absence.AbsencseTypeId)
            .IsRequired();

        builder
            .HasOne(absence => absence.Employee)
            .WithMany(employee => employee.Vacations)
            .HasForeignKey(absence => absence.EmployeeId)
            .IsRequired();
    }
}
