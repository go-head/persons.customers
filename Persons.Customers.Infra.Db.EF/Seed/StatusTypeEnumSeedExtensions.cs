using Microsoft.EntityFrameworkCore;
using Persons.Customers.Domain.Enums;

namespace Persons.Customers.Infra.Db.EF.Seed;

public static class StatusTypeEnumSeedExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerStatusTypeEnum>().HasData(
            CustomerStatusTypeEnum.ACTIVE,
            CustomerStatusTypeEnum.BLOCKED,
            CustomerStatusTypeEnum.CANCELED
            );

        modelBuilder.Entity<DocumentTypeEnum>().HasData(
            DocumentTypeEnum.CPF,
            DocumentTypeEnum.RG,
            DocumentTypeEnum.CNPJ);
    }
}