using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Enums;
using System.Reflection.Metadata;

namespace Persons.Customers.Infra.Db.EF.Configs;

public class CustomerEntityConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);

        builder.Property(s => s.DocumentNumber).IsRequired();
        builder.Property(s => s.RegisterName).IsRequired();
        builder.Property(s => s.BirthDate)
            .HasColumnType("datetime2");

        builder.Property(s => s.Email);

        //builder.Property(s => s.Address);
        //builder.Property(s => s.Document);

        builder
            .Property<int>("_statusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("StatusId")
            .IsRequired();

        builder.Property(s => s.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(s => s.CreatedBy)
            .HasColumnType("nvarchar(150)")
            .IsRequired();

        builder
            .HasOne(e => e.Status)
            .WithMany()
            .HasForeignKey("_statusId");

        builder
            .HasOne(s => s.Address)
            .WithOne()
            .HasForeignKey<Address>("CustomerId")
            .IsRequired(false);

        builder
            .HasOne(s => s.Document)
            .WithOne(s => s.Customer)
            .HasForeignKey<CustomerDocument>("_customerId")
            .IsRequired();
    }
}