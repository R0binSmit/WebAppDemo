using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.DataAccess.Entities;

namespace WebAppDemo.DataAccess.EntityConfigurations;

public class VacationTypeConfiguration : IEntityTypeConfiguration<VacationType>
{
    public void Configure(EntityTypeBuilder<VacationType> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(e => e.Name)
            .IsUnique();
    }
}
