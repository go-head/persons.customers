using Persons.Customers.Domain.Abstractions;
using Persons.Customers.Domain.Enums;

namespace Persons.Customers.Domain.Entities
{
    public class CustomerDocument : Entity
    {
        public CustomerDocument()
        { }

        public CustomerDocument(DocumentTypeEnum documentType, string documentNumber)
        {
            _documentTypeId = documentType.Id;
            DocumentNumber = documentNumber;
        }

        public string DocumentNumber { get; set; }

        private int _documentTypeId;
        public DocumentTypeEnum? DocumentType { get; private set; }

        private Guid _customerId;
        public Customer? Customer { get; private set; }
    }
}