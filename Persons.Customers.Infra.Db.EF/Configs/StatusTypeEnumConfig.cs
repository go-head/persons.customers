using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Customers.Domain.Enums;

namespace Persons.Customers.Infra.Db.EF.Configs;

public class StatusTypeEnumConfig : IEntityTypeConfiguration<CustomerStatusTypeEnum>
{
    public void Configure(EntityTypeBuilder<CustomerStatusTypeEnum> builder)
    {
        builder.ToTable("CustomerStatusesType");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(s => s.Name)
            .HasMaxLength(150)
            .IsRequired();
    }
}