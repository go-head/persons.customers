using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Customers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Customers.Infra.Db.EF.Configs;

public class CustomerDocumentConfig : IEntityTypeConfiguration<CustomerDocument>
{
    public void Configure(EntityTypeBuilder<CustomerDocument> builder)
    {
        builder.ToTable("CustomerDocuments");

        builder.HasKey(x => x.Id);

        builder
            .Property<int>("_documentTypeId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("DocumentTypeId")
            .IsRequired();

        builder
            .Property<Guid>("_customerId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CustomerId")
            .IsRequired();

        builder
            .HasOne(e => e.DocumentType)
            .WithMany()
            .HasForeignKey("_documentTypeId");
    }
}