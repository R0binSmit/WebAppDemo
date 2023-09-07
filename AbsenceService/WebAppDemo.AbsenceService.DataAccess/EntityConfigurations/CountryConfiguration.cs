using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.AbsenceService.DataAccess.EntityConfigurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .HasKey(country => country.Id);

        builder
            .Property(country => country.FullName)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode();

        builder
            .Property(country => country.ShortName)
            .IsRequired()
            .HasMaxLength(3)
            .IsUnicode();

        builder
            .HasMany(country => country.States)
            .WithOne(state => state.Country)
            .HasForeignKey(country => country.CountryId)
            .IsRequired();
    }
}
