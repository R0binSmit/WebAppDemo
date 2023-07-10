using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.VacationService.DataAccess.Entities;

namespace WebAppDemo.VacationService.DataAccess.EntityConfigurations;

internal class StateConfiguration : IEntityTypeConfiguration<State>
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
