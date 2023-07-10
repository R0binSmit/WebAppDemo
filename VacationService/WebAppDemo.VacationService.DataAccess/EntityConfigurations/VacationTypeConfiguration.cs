using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.VacationService.DataAccess.Entities;

namespace WebAppDemo.VacationService.DataAccess.EntityConfigurations;

internal class VacationTypeConfiguration : IEntityTypeConfiguration<VacationType>
{
    public void Configure(EntityTypeBuilder<VacationType> builder)
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
            .HasMany(vacationType => vacationType.Vacations)
            .WithOne(vacation => vacation.VacationType)
            .HasForeignKey(vacation => vacation.VacationTypeId);
    }
}
