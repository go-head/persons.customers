using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Enums;

namespace Persons.Customers.Infra.Db.EF.Configs;

public class AddressEntityConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("CustomerAddresses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(s => s.Zipcode);

        builder.Property(s => s.AddressLine);

        builder.Property(s => s.BuildingNumber);

        builder.Property(s => s.Neighborhood);

        builder.Property(s => s.Country);

        builder.Property(s => s.State);

        builder.Property(s => s.City);
    }
}