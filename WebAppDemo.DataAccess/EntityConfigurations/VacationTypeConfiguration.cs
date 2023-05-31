using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.DataAccess.Entities;

namespace WebAppDemo.DataAccess.EntityConfigurations;

public class VacationTypeConfiguration : IEntityTypeConfiguration<VacationType>
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
    }
}
