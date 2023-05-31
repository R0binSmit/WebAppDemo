using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.DataAccess.Entities;

namespace WebAppDemo.DataAccess.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
    .HasKey(e => e.Id);

        builder
            .HasOne(address => address.State)
            .WithMany(state => state.Addresses)
            .HasForeignKey(address => address.StateId)
            .IsRequired();

        builder
            .Property(address => address.City)
            .IsRequired()
            .HasMaxLength(150);

        builder
            .Property(address => address.Street)
            .IsRequired()
            .HasMaxLength(150);

        builder
            .Property(address => address.ZipCode)
            .IsRequired()
            .HasMaxLength(12);

        builder
            .Property(address => address.HouseNumber)
            .IsRequired()
            .HasMaxLength(10);

        builder
            .Property(address => address.HouseNumberAddition)
            .HasDefaultValue(string.Empty);
    }
}
