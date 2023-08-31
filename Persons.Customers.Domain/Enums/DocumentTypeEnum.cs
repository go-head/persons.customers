using Persons.Customers.Domain.Abstractions;

namespace Persons.Customers.Domain.Enums
{
    public class DocumentTypeEnum : Enumeration
    {
        public static DocumentTypeEnum CPF = new DocumentTypeEnum(1, nameof(CPF));
        public static DocumentTypeEnum CNPJ = new DocumentTypeEnum(2, nameof(CNPJ));
        public static DocumentTypeEnum RG = new(3, nameof(RG));

        public DocumentTypeEnum(int id, string name)
            : base(id, name) { }
    }
}