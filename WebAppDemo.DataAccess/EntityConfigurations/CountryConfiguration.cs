using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.DataAccess.Entities;

namespace WebAppDemo.DataAccess.EntityConfigurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .HasKey(country => country.Id);

        builder
            .Property(country => country.FullName)
            .IsRequired()
            .HasMaxLength(150)
            .IsUnicode();

        builder
            .Property(country => country.ShortName)
            .IsRequired()
            .HasMaxLength(2)
            .IsUnicode();

        builder
            .HasMany(country => country.States)
            .WithOne(state => state.Country)
            .HasForeignKey(country => country.CountryId)
            .IsRequired();
    }
}
