using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Customers.Domain.Enums;

namespace Persons.Customers.Infra.Db.EF.Configs;

public class DocumentTypeEnumConfig : IEntityTypeConfiguration<DocumentTypeEnum>
{
    public void Configure(EntityTypeBuilder<DocumentTypeEnum> builder)
    {
        builder.ToTable("DocumentType");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(s => s.Name)
            .HasMaxLength(150)
            .IsRequired();
    }
}