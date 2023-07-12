using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.VacationService.DataAccess.EntityConfigurations;

internal class AbsenceTypeConfiguration : IEntityTypeConfiguration<AbsenceType>
{
    public void Configure(EntityTypeBuilder<AbsenceType> builder)
    {
        builder
            .HasKey(vacationType => vacationType.Id);

        builder
            .Property(vacationType => vacationType.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(vacationType => vacationType.Name)
            .IsUnique();

        builder
            .HasMany(vacationType => vacationType.Absences)
            .WithOne(vacation => vacation.AbsenceType)
            .HasForeignKey(vacation => vacation.AbsencseTypeId);
    }
}
