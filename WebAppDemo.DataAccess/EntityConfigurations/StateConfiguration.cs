using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.DataAccess.Entities;

namespace WebAppDemo.DataAccess.EntityConfigurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder
            .HasKey(state => state.Id);

        builder
            .Property(state => state.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(state => state.Name)
            .IsUnique();

        builder
            .HasOne(state => state.Country)
            .WithMany(country => country.States)
            .HasForeignKey(state => state.CountryId)
            .IsRequired();
    }
}
