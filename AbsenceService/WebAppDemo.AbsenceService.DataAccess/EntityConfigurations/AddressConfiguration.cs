using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppDemo.AbsenceService.DataAccess.Entities;

namespace WebAppDemo.AbsenceService.DataAccess.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasKey(address => address.Id);

        builder
            .HasOne(address => address.State)
            .WithMany(state => state.Addresses)
            .HasForeignKey(address => address.StateId)
            .IsRequired();

        builder
            .Property(address => address.City)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(address => address.Street)
            .IsRequired()
            .HasMaxLength(100);

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

        builder
            .HasMany(address => address.Employees)
            .WithOne(employee => employee.Address)
            .HasForeignKey(employee => employee.AddressId);
    }
}
