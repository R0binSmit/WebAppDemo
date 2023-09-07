using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.AbsenceService.DataAccess.EntityConfigurations;

public class AbsenceTypeConfiguration : IEntityTypeConfiguration<AbsenceType>
{
    public void Configure(EntityTypeBuilder<AbsenceType> builder)
    {
        builder
            .HasKey(absenceType => absenceType.Id);

        builder
            .Property(absenceType => absenceType.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(absenceType => absenceType.Name)
            .IsUnique();

        builder
            .HasMany(absenceType => absenceType.Absences)
            .WithOne(absence => absence.AbsenceType)
            .HasForeignKey(absence => absence.AbsencseTypeId);
    }
}
